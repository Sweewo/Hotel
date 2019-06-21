using Hotel.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Hotel.Application.Tests
{
    public class UnitTest1
    {
        public class TestBase
        {
            public HotelDbContext GetDbContext()
            {
                var builder = new DbContextOptionsBuilder<HotelDbContext>();
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

                var dbContext = new HotelDbContext(builder.Options);

                dbContext.Database.EnsureCreated();

                return dbContext;
            }
        }
    }
}
