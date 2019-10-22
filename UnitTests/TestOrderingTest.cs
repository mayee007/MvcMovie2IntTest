using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie2.Models; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net;
using Xunit.Abstractions;
using System;
using MvcMovie2IntTest.Utils;
using Xunit.Priority;

namespace MvcMovie2IntTest.UnitTests 
{
    // This line is required in the beginning 
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class TestOrderingTest //: MakeConsoleWork
    {
        private readonly ITestOutputHelper _output;

        //public TestOrderingTest(ITestOutputHelper output) : base(output)
        public TestOrderingTest(ITestOutputHelper output)
        {
            _output = output; 
        }

        // Max the value, will run last 
        [Fact, Priority(30)]
        public void aboutNotNullTest() 
        {
            _output.WriteLine("inside test1 ***************************************************************");
            Assert.False(true); 
        }

        [Fact, Priority(4)]
        public void aboutNotNullTest4()
        {
            _output.WriteLine("inside test2 --------------------------------------------------------------");
            Assert.False(true);
        }

        [Fact, Priority(1)]
        public void aboutNotNullTest3()
        {
            _output.WriteLine("inside test3 --------------------------------------------------------------");
            Assert.False(true);
        }
    }
}