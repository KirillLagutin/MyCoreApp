using Microsoft.EntityFrameworkCore;
using MyCoreApp.Data;

namespace MyCoreApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MyCoreAppContext
            (
                serviceProvider.GetRequiredService<DbContextOptions<MyCoreAppContext>>()
            );
            
            if(context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null MyAppCoreContext");
            }

            if(context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange
            (
                new Movie
                {
                    Title = "1",
                    ReleaseDate = DateTime.Parse("1999-09-09"),
                    Genre = "a",
                    Price = 655.08M,
                    Rating = "+18"
                },
                new Movie
                {
                    Title = "2",
                    ReleaseDate = DateTime.Parse("1999-09-10"),
                    Genre = "b",
                    Price = 125.08M,
                    Rating = "+16"
                },
                new Movie
                {
                    Title = "3",
                    ReleaseDate = DateTime.Parse("1999-09-11"),
                    Genre = "c",
                    Price = 345.08M,
                    Rating = "+16"
                }
            );

            context.SaveChanges();
        }
    }
}
