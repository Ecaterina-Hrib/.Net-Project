using Microsoft.EntityFrameworkCore;
using HousePricePrediction.API.Persitence.Context;
using System;

namespace HousePricePrediction.API.Tests
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly DatabaseContext dataContext;

        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseInMemoryDatabase("Database")
                    .Options;

            dataContext = new DatabaseContext(options);
            dataContext.Database.EnsureCreated();
           // DatabaseInitializer.Initialize(dataContext);
        }

        public void Dispose()
        {
            dataContext.Database.EnsureDeleted();
            dataContext.Dispose();
        }
    }
}