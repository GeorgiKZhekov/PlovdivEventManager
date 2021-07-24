

namespace PlovdivEventManager.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using PlovdivEventManager.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using PlovdivEventManager.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<PlovdivEventManagerDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(PlovdivEventManagerDbContext data)
        {
            //Seeding category. If to much of these Methods apear, whole functionality should be extracted in Folder

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Music"},
                new Category { Name = "Theatre"},
                new Category { Name = "Art"},
                new Category { Name = "Education"},
                new Category { Name = "Stand-Up Comedy"},
                new Category { Name = "Food and Drinks"},
                new Category { Name = "Kids friendly"},
                new Category { Name = "Health and Wealness"},
                new Category { Name = "Sport"},
                new Category { Name = "Family"},
                new Category { Name = "Charity"},
                new Category { Name = "Online"},
            });

            data.SaveChanges();
        }
    }
}
