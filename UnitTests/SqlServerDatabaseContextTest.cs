using System;
using Xunit;
using MvcMovie2IntTest.utils;
using MvcMovie2.Controllers;
using MvcMovie2.Models;

namespace MvcMovie2IntTest.UnitTests
{
    public class SqlServerDatabaseContextTest
    {
        [Fact]
        public void Test1()
        {
            MvcMovieContext context = DbAccess.getSqlServerDbContext();

            context.Movie.Add(new Movie { Genre = "Classic", Title = "Redemption", Price = 10.05M, ReleaseDate = new DateTime(2001, 1, 18) });
            context.Movie.Add(new Movie { Genre = "Classic", Title = "Shark", Price = 15.05M, ReleaseDate = new DateTime(2005, 5, 23) });
            context.SaveChanges(); 

            MoviesController controller = new MoviesController(context);
 
            Assert.True(controller.MovieExists(1));
            Assert.True(controller.MovieExists(2));
            Assert.False(controller.MovieExists(10));
        }

        public void MovieTable()
        {
            // query to create table "Movie" in "SQL Server" database
            /* create table Movie (
	            Id int primary key identity, 
	            Title varchar(255), 
	            ReleaseDate varchar(255), 
	            Genre varchar(255), 
	            Price decimal
               );
            */
        }
    }
}
