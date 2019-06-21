using Hotel.Application.Queries.Users.GetUser;
using MediatR;

namespace Hotel.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<UserViewModel>
    {
        public string Token { get; set; }
    }
}
