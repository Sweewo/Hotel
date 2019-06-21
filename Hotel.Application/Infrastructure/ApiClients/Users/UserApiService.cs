using AutoMapper;
using Hotel.Application.Interfaces.ApiClients.Users;
using Hotel.Domain.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hotel.Application.Infrastructure.ApiClients.Users
{
    public class UserApiService : IUserApiService
    {
        private readonly IMapper mapper;
        private readonly IOptions<SettingsModel> settings;

        public UserApiService(IMapper mapper, IOptions<SettingsModel> settings)
        {
            this.mapper = mapper;
            this.settings = settings;
        }

        public async Task<User> LoadUserFromAuthServerAsync(string token)
        {
            var data = await HttpClientHelper.ObtainData(settings.Value.UserAuthInfoEndpoint + token);
            var userDto = JsonConvert.DeserializeObject<UserOauthDto>(data);

            var user = mapper.Map<User>(userDto);

            return user;
        }
    }
}
