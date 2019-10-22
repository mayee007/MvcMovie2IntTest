using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie2.Models;
using Microsoft.Extensions.Configuration; 

namespace MvcMovie2IntTest.Utils
{
    public class DatabaseFixture : IDisposable
    {
        public MvcMovieContext _context { get; set; }

        // config to store data from JSON file 
        public IConfigurationRoot config { get; set; }

        public DatabaseFixture()
        {
            // read config file 
            config = new ConfigurationBuilder()
                .AddJsonFile("C:\\Users\\mayee\\source\\repos\\MvcMovie2IntTest\\appconfig.json")
                .Build();

            
            // setup database context 
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MvcMovieContext>();

            builder.UseSqlServer($"Initial Catalog=MovieDatabase;Data Source=TRISHUL;Integrated Security=SSPI;")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MvcMovieContext(builder.Options);

            // reset "Movie" table auto-increment counter 
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Movie, RESEED, 0)");

            // populate test data
            SeedTestData.PopulateTestData(_context); 

            //_context.Database.Migrate();            
        }
        public void Dispose()
        {
            // probably remove or close database connection 
            _context.Database.ExecuteSqlCommand("delete from Movie"); 
        }
    }
}
