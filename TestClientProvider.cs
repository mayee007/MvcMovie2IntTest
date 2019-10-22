using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using MvcMovie2;
using Microsoft.AspNetCore;
using System.Net.Http;

namespace MvcMovie2IntTest
{
    public class TestClientProvider
    {
        public HttpClient client { get; set; }

        public TestClientProvider()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            client = new TestServer(builder).CreateClient();
        }
    }
}
