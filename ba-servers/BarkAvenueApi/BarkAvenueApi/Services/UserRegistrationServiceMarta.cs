using System;
using System.Threading.Tasks;
using BarkAvenueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Services
{
    public class UserRegistrationServiceMarta
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly EmailService _emailService;

        //public UserRegistrationServiceMarta(ApplicationDbContext dbContext, EmailService emailService)
        //{
        //    _dbContext = dbContext;
        //    _emailService = emailService;
        //}

        public async Task<bool> IsUserExists(string email)
        {
            return await _dbContext.users.AnyAsync(u => u.email == email);
        }

        public async Task<bool> RegisterUser(RegistrationDTO registrationDTO)
        {
            // Check if user already exists
            if (await IsUserExists(registrationDTO.Email))
            {
                // User with this email already exists
                return false;
            }

            // Create user entity from DTO
            var user = new User
            {
                username = registrationDTO.Username,
                email = registrationDTO.Email,
                phone_number = registrationDTO.Phone_number,
                password_user = registrationDTO.Password_user,
                role_user = "User", // Assuming default role is "User"
                date_registration = DateTimeOffset.UtcNow,
                last_login = DateTimeOffset.UtcNow,
                is_active = false, // Assuming newly registered users are inactive until confirmed
                permission_user = "Normal" // Assuming default permission is "Normal"
            };

            // Save user to database
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Send confirmation email
           //await _emailService.SendConfirmationEmail(registrationDTO.Email);

            return true;
        }
    }
}