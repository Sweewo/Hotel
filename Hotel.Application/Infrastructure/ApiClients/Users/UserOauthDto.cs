using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Enums;
using Hotel.Domain.Models;
using System.Collections.Generic;

namespace Hotel.Application.Infrastructure.ApiClients.Users
{
    public class UserOauthDto : ICustomMapping
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IList<string> Authorities { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UserOauthDto, User>()
                .ForMember(u => u.UserType, m => m.MapFrom(ud => ud.Authorities.Count > 1 ? UserType.Manager : UserType.Guest));
            ;
        }
    }
}
