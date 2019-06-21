using AutoMapper;
using Hotel.Persistance;
using System;
using Xunit;

namespace Hotel.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public HotelDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = HotelContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            HotelContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
