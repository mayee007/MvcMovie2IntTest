using System;
using Xunit;
using MvcMovie2IntTest.utils;
using MvcMovie2.Controllers;
using MvcMovie2.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie2IntTest.UnitTests
{
    public class InMemoryDatabaseContextTest
    {
        MoviesController controller;
        public InMemoryDatabaseContextTest()
        {
            controller = new MoviesController(DbAccess.getInMemoryDatabaseContext());

            // prep data 
            Movie movie1 = new Movie()
            {
                Title = "Shrek"
            };
            Movie movie2 = new Movie()
            {
                Title = "Another"
            };
            controller.Create(movie1);
            controller.Create(movie2);
        }
        [Fact]
        public void InMemoryDB_Count_Test()
        {
            // verify both movies are added 
            Assert.True(controller.MovieExists(1));
            Assert.True(controller.MovieExists(2));

            // Failed test cases, movie with ID 10 not added 
            Assert.False(controller.MovieExists(10));

            var result = controller.Details(1).Result;
            //Assert.Equal(movie1.GetType(), result.GetType());
        }

        [Fact]
        public void InMemoryDB_Details_Test()
        {
            var result = controller.Details(1).Result; 
            //Assert.Equal(movie1.GetType(), result.GetType());
        }

        [Theory]
        [InlineData("third one", 6)] // this gets executed afterwards, along with other 3 and constructor 2
        [InlineData("fourth one", 3)] // since this gets executed first, there would be 3 movies
        public void verifyAddMovie(String title, int id)
        {
            Movie movie = new Movie()
            {
                Title = title
            };
            var result = controller.Create(movie);

            // verify status is successful 
            Assert.Equal("RanToCompletion" , result.Status.ToString());

            
            // verify new ID is added 
            Assert.Equal(id, movie.Id);
            Assert.Equal(title, movie.Title); 
        }
        [Fact]
        public void verifyAddMovieFailure()
        {
            Movie movie = new Movie()
            {
                Id = 1, 
                Title = "fifth one"
            };
            var result = controller.Create(movie);

            // verify status is faulted 
            Assert.Equal("Faulted", result.Status.ToString());

            // verify new ID is NOT added 
            Assert.Equal(1, movie.Id);
            Assert.Equal("fifth one", movie.Title);
        }

        [Fact]
        public void verifyAddMovieResults()
        {
            Movie movie = new Movie()
            {
                Title = "third one"
            };
            var result = controller.Create(movie);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testMovie = Assert.IsType<Movie>(viewResult.Model);

        }
    }
}
