using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvcMovie2.Models;
using MvcMovie2.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite; 
namespace MvcMovie2IntTest.utils
{
    public class DbAccess
    {
        public static string GetTestConnectionString()
        {
            const string databaseName = "MovieDatabase";
            string databaseUsername = "";
            string databasePassword = "";

            return $"Server=localhost;" +
                   $"database={databaseName};" +
                   $"uid={databaseUsername};" +
                   $"pwd={databasePassword};" +
                   $"pooling=true;";
        }

        public static MvcMovieContext getSqlServerDbContext()
        {
            MvcMovieContext _context; 

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MvcMovieContext>();

            //builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=MovieDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
            //builder.UseSqlServer($"Server=TRISHUL\\mayee;Database=MovieDatabase_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
            // connect to database using windows authentication 
            builder.UseSqlServer($"Initial Catalog=MovieDatabase;Data Source=TRISHUL;Integrated Security=SSPI;")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MvcMovieContext(builder.Options);
            _context.Database.Migrate();
            return _context; 
        }

        public static MvcMovieContext getSqlLiteDbContext()
        {
            MvcMovieContext _context;

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MvcMovieContext>();

            //builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=MovieDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
            //builder.UseSqlServer($"Server=TRISHUL\\mayee;Database=MovieDatabase_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
            // connect to database using windows authentication 
            builder.UseSqlite($"Data Source=MvcMovie.db")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MvcMovieContext(builder.Options);
            _context.Database.Migrate();
            return _context;
        }

        public static MvcMovieContext getInMemoryDatabaseContext()
        {
            DbContextOptions<MvcMovieContext> options;
            var builder = new DbContextOptionsBuilder<MvcMovieContext>();

            builder.UseInMemoryDatabase();
            options = builder.Options;
            MvcMovieContext personDataContext = new MvcMovieContext(options);
            personDataContext.Database.EnsureDeleted();
            personDataContext.Database.EnsureCreated();
            return personDataContext;
        }

        public static MvcMovieContext getSqlLiteDbContext2()
        {
            MvcMovieContext _context;

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();
            
            var builder = new DbContextOptionsBuilder<MvcMovieContext>();

            //builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=MovieDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
            //builder.UseSqlServer($"Server=TRISHUL\\mayee;Database=MovieDatabase_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
            // connect to database using windows authentication 
            builder.UseSqlite($"Data Source=MvcMovie.db")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MvcMovieContext(builder.Options);
            _context.Database.Migrate();
            return _context;
        } // end of function  getSqlLiteDbContext2

    } // end of class DbAccess
}
