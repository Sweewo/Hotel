using Hotel.Domain.Models;
using System.Threading.Tasks;

namespace Hotel.Application.Interfaces.ApiClients.Users
{
    public interface IUserApiService
    {
        Task<User> LoadUserFromAuthServerAsync(string tokenUrl);
    }
}
