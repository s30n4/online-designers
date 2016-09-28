using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OD.DataLayer.Migrations
{
    public static class DbInitialization
    {
        public static void Initialize(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                // Applies any pending migrations for the context to the database.
                // Will create the database if it does not already exist.
                context.Database.Migrate();
            }
        }
    }
}
