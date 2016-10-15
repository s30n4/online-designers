using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OD.DataLayer;
using OD.DataLayer.Migrations;
using OD.Presentation.Ioc;
using SGE.Framework.Domain.Uow.Contracts;
using StructureMap;

namespace OD.Presentation
{
    public class Startup
    {
        public IConfigurationRoot Configuration { set; get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                .AddJsonFile($"appsettings.{env}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(provider => Configuration);

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            var container = new Container();

            Mapper.Initialize(x => { x.AddProfiles(ProjectAssemblies.ServiceLayer); });

            var mapper = Mapper.Instance; // configuration.CreateMapper();

            services.AddSingleton(typeof(IMapper), mapper);


            ServiceIoc.Ioc(services);

            container.Populate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IServiceScopeFactory scopeFactory)
        {
            scopeFactory.SeedData();
            scopeFactory.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home";
                    await next();
                }
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowSpecificOrigin");

            // Register a simple error handler to catch token expiries and change them to a 401,
            // and return all other errors as a 500. This should almost certainly be improved for
            // a real application.
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error?.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        // TODO: Shouldn't pass the exception message straight out, change this.
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject
                                (new { success = false, error = error.Error.Message }));
                    }
                    // We're not trying to handle anything else so just let the default
                    // handler handle.
                    else await next();
                });
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
