using System;
using System.Threading.Tasks;
using BarkAvenueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Services
{
    public class UserRegistrationServiceMarta : IUserRegistrationServiceMarta
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly EmailService _emailService;

        public UserRegistrationServiceMarta(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> UserExists(string email)
        {
            try
        {
            return await _dbContext.users.AnyAsync(u => u.email == email);
        }
            catch (Exception ex)
            {
                // Обробка помилок під час перевірки існування користувача
                Console.WriteLine($"Помилка при перевірці існування користувача: {ex}");
                return false;
            }
        }

        public async Task<bool> RegisterUser(RegistrationDTO registrationDTO)
        {
            try
            {
                if (await UserExists(registrationDTO.Email))
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
                    role_user = "User",
                date_registration = DateTimeOffset.UtcNow,
                last_login = DateTimeOffset.UtcNow,
                    is_active = false,
                    permission_user = "Normal"
            };

            // Save user to database
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Send confirmation email
           //await _emailService.SendConfirmationEmail(registrationDTO.Email);

            return true;
        }
            catch (Exception ex)
            {
                // Обробка помилок під час реєстрації користувача
                Console.WriteLine($"Помилка при реєстрації користувача: {ex}");
                return false;
            }
        }

        public Task RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}