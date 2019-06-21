using AutoMapper;
using Hotel.Application.Queries.Users.GetUser;
using Hotel.Application.Tests.Infrastructure;
using Hotel.Domain.Enums;
using Hotel.Persistance;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hotel.Application.Tests.Queries.Users
{
    [Collection("QueryCollection")]
    public class GetUserQueryHandlerTests
    {
        private readonly HotelDbContext context;
        private readonly IMapper mapper;

        public GetUserQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserTest()
        {
            var sut = new GetUserQueryHandler(context, mapper);

            var result = await sut.Handle(new GetUserQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<UserViewModel>();

            result.Username.ShouldBe("Guest1");
            result.UserType.ShouldBe(UserType.Guest.ToString());
        }
    }
}
