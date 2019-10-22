using System;
using MvcMovie2.Models;
namespace MvcMovie2IntTest
{
    class SeedTestData
    {
        public static void PopulateTestData(MvcMovieContext dbContext)
        {
            dbContext.Movie.Add(new Movie()
                {
                    Title = "Shrek"
                }
            );
            dbContext.Movie.Add(new Movie()
            {
                Title = "Shark"
            }
            );
            dbContext.SaveChanges();
        }
    }
}
