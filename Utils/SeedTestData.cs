using System;
using MvcMovie2.Models;
namespace MvcMovie2IntTest.Utils
{
    class SeedTestData
    {
        public static void PopulateTestData(MvcMovieContext dbContext)
        {
            // remove everything
            //dbContext.Movie.Remove(new Movie { Id = 1 });
            //dbContext.Movie.Remove(new Movie { Id = 2 });
            //dbContext.Movie.Remove(new Movie { Id = 3 });

            // add movies to "Movie" table 
            dbContext.Movie.Add(new Movie { Genre = "Classic", Title = "Shawshank Redemption", Price = 10.05M, ReleaseDate = new DateTime(2001, 1, 18) });
            dbContext.Movie.Add(new Movie { Genre = "Thriller", Title = "Shark", Price = 15.05M, ReleaseDate = new DateTime(2005, 5, 23) });
            dbContext.Movie.Add(new Movie { Genre = "Kids", Title = "IceAge", Price = 56.34M, ReleaseDate = new DateTime(2001, 6, 6) });

            dbContext.SaveChanges();
        }
    }
}
