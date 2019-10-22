using Microsoft.AspNetCore.Mvc.Testing;
using MvcMovie2;
using MvcMovie2.tests.ControllerTests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit; 
namespace MvcMovie2IntTest.IntegrationTests
{
    public class MovieIntegrationFactoryTest
    {
        public HttpClient client;

        public MovieIntegrationFactoryTest()
        {
            var factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [Fact]
        public async void test1()
        {
            var client = new TestClientProvider().client;
            var response = await client.GetAsync("/Movies");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 
        }

        [Fact]
        public void test2()
        {
            Console.WriteLine("inside test1()"); 
        }

        [Fact]
        public void test3()
        {
            Console.WriteLine("inside test2()");
        }
    }
}
