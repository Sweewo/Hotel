using AutoMapper;
using Hotel.Application.Queries.Rooms.GetAllRooms;
using Hotel.Application.Tests.Infrastructure;
using Hotel.Persistance;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hotel.Application.Tests.Queries.Rooms
{
    [Collection("QueryCollection")]
    public class GetAllRoomsQueryHandlerTests
    {
        private readonly HotelDbContext context;
        private readonly IMapper mapper;

        public GetAllRoomsQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllRoomsTest()
        {
            var sut = new GetAllRoomsQueryHandler(context, mapper);

            var result = await sut.Handle(new GetAllRoomsQuery(), CancellationToken.None);

            result.Count().ShouldBe(3);
            result.ShouldBeOfType<List<RoomViewModel>>();
        }
    }
}
