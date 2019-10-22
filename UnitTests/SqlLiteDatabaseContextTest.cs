using System;
using Xunit;
using MvcMovie2IntTest.utils;
using MvcMovie2.Controllers;
using MvcMovie2.Models;

namespace MvcMovie2IntTest.UnitTests
{
    public class SqlLiteDatabaseContextTest
    {
        [Fact]
        public void sqlLiteTests()
        {
            MoviesController controller = new MoviesController(DbAccess.getSqlLiteDbContext());
            Movie movie1 = new Movie()
            {
                Title = "Shrek"
            };
            Movie movie2 = new Movie()
            {
                Title = "Another"
            };
            var x = controller.Create(movie1);
            var y = controller.Create(movie2);
            //controller.Create(movie1); 
            Assert.True(controller.MovieExists(1));
            //Assert.True(controller.MovieExists(2));
            //Assert.False(controller.MovieExists(10));
        }

        [Fact]
        public void sqlLiteTests2()
        {
            
            MoviesController controller = new MoviesController(DbAccess.getSqlLiteDbContext());
            Movie movie1 = new Movie()
            {
                Title = "Shrek"
            };
            Movie movie2 = new Movie()
            {
                Title = "Another"
            };
            var x = controller.Create(movie1);
            var y = controller.Create(movie2);
            //controller.Create(movie1); 
            Assert.True(controller.MovieExists(1));
            //Assert.True(controller.MovieExists(2));
            //Assert.False(controller.MovieExists(10));
        }
    }
}
