using Hotel.Application.Queries.Users.GetUser;
using MediatR;

namespace Hotel.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
