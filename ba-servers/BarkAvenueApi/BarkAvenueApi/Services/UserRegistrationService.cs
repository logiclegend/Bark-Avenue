using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarkAvenueApi.Models;

namespace BarkAvenueApi.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRegistrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _dbContext.users.AnyAsync(u => u.username == username);
        }

        public async Task<ServiceResponse> RegisterUser(User user)
        {
            try
            {
                user.date_registration = DateTime.Now;
                user.is_active = true; // Set default active status
                user.permission_user = "Default"; // Set default permission

                _dbContext.users.Add(user);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse { Success = true };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ServiceResponse { Success = false, ErrorMessage = ex.Message };
            }
        }
    }

    public interface IUserRegistrationService
    {
        Task<bool> UserExists(string username);
        Task<ServiceResponse> RegisterUser(User user);
    }

    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}

