using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OD.DataLayer.Migrations
{
    public static class ApplicationDbContextSeedData
    {
        public static void SeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                //var context = serviceScope.ServiceProvider.GetService<SaminDbContext>();
                //if (context.Comment.Any()) return;
                //var comments = new List<Comment>
                //{
                //    new Comment
                //    {
                //        Body = "Test Body",
                //        Subject = "Test Subject"

                //    }
                //};
                //context.AddRange(comments);
                //context.SaveChanges();
            }
        }
    }
}
