using MediatR;

namespace Hotel.Application.Queries.Users.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }
    }
}
