using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OD.DataLayer;
using SGE.Framework.Domain.Uow.Contracts;

namespace OD.Presentation.Ioc
{
    public class ServiceIoc
    {
        public static void Ioc(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          

            #region Core

           

            #endregion Core

            #region Modules

        

            #endregion Modules
        }
    }
}
