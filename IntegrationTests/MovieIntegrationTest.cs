using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit; 
namespace MvcMovie2IntTest.IntegrationTests
{
    public class MovieIntegrationTest
    {
        [Fact]
        public async void test1()
        {
            var client = new TestClientProvider().client;
            var response = await client.GetAsync("/Movies");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 
        }

        [Fact]
        public void mockTest()
        {
            
        }
    }
}
