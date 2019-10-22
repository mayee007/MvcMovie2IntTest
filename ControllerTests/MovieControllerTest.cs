using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MvcMovie2.Models; 
using Xunit;
using MvcMovie2IntTest.Utils;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MvcMovie2IntTest.ControllerTests 
{
    public class MovieControllerTest : IClassFixture<CustomDbFactory<MvcMovie2.Startup>>
    {
        HttpClient _client;

        public MovieControllerTest(CustomDbFactory<MvcMovie2.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        [Trait("Category", "ControllerTests")]
        public async Task CanGetMovies()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/Movies");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(stringResponse);
            Assert.Contains(movies, p => p.Title == "Shrek");
            Assert.Contains(movies, p => p.Title == "Shark");
        }

        [Fact]
        public void getDbContext()
        {
            
        }

    }
}
