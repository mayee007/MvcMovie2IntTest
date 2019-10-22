using System;
using Xunit;
using MvcMovie2IntTest.utils;
using MvcMovie2.Controllers;
using MvcMovie2.Models;
using MvcMovie2IntTest.Utils;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie2IntTest.ControllerTests
{
    //[Collection("Database collection")]
    /*
     * When this class gets called, "DatabaseFixture" class gets called 
     * and constructor gets invoked, which provides database context automatically 
     */
    public class MovieControllerIntegrationTest : IClassFixture<DatabaseFixture>
    {
        MoviesController controller;
        DatabaseFixture fixture; 

        public MovieControllerIntegrationTest(DatabaseFixture fixture) // dependency injection 
        {
            this.fixture = fixture; 
            controller = new MoviesController(fixture._context); // we have actual db context 
        }  

        [Fact]
        public void verifyMoviesById()
        {
            
            Assert.True(controller.MovieExists(1)); // this data was added from "seed"
            Assert.True(controller.MovieExists(2)); // this data was added from "seed"
            Assert.False(controller.MovieExists(10));
        }

        [Fact]
        public void verifyMovieDetailsById()
        {            
            Console.WriteLine(fixture.config);
            Console.WriteLine(fixture.config["appName"]);

            var actionTask = controller.Details(1);
            actionTask.Wait();
            //var result = actionTask.Result as ViewResult;
            //Assert.NotNull(result);
            //Assert.Equal("Details", result.ViewName);
        }

        [Fact]
        public void test1()
        {

        }

        [Fact]
        public async void verifyMovieDetailsByIdSecondWay()
        {
            IActionResult result = controller.Details(1).Result;
            
            //var result = actionResult as ViewResult;
            //Assert.NotNull(result);
            //Assert.Equal("Details", result.ViewName);
        }
    }
}
