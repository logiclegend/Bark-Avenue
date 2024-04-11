using System.Threading.Tasks;
using BarkAvenueApi.Models;

namespace BarkAvenueApi.Services
{
    public interface IUserRegistrationServiceMarta
    {
        Task<bool> UserExists(string email);
        Task<bool> RegisterUser(RegistrationDTO registrationDTO);
        Task RegisterUser(User user);
    }
}