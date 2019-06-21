using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;

namespace Hotel.Application.Queries.Users.GetUser
{
    public class UserViewModel : ICustomMapping
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string UserType { get; set; }
        public string AdditionalInfo { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(uvm => uvm.UserType, m => m.MapFrom(u => u.UserType.ToString()))
                ;
        }
    }
}
