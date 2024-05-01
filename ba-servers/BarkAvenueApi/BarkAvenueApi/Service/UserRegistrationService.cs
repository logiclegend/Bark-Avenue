using System;
using System.Threading.Tasks;
using BarkAvenueApi.Email;
using BarkAvenueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmailService _emailService;

        public UserRegistrationService(ApplicationDbContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<bool> UserExists(string email)
        {
            try
            {
                return await _dbContext.users.AnyAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while checking if user exists: {ex}");
                return false;
            }
        }

        public async Task<bool> RegisterUser(RegistrationDTO registrationDTO)
        {
            try
            {
                if (await UserExists(registrationDTO.Email))
                {
                    return false;
                }

                var user = new User
                {
                    Username = registrationDTO.Username,
                    Email = registrationDTO.Email,
                    PhoneNumber = registrationDTO.Phone_number,
                    PasswordUser = registrationDTO.Password_user,
                    RoleUser = "User",
                    DateRegistration = DateTime.UtcNow,
                    LastLogin = DateTime.UtcNow,
                    IsActive = false,
                    PermissionUser = "Normal"
                };

                _dbContext.users.Add(user);
                await _dbContext.SaveChangesAsync();

                var mailRequest = _emailService.CreateWelcomeEmail(registrationDTO.Email);

                await _emailService.SendEmailAsync(mailRequest);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while registering user: {ex}");
                return false;
            }
        }
    }
}
