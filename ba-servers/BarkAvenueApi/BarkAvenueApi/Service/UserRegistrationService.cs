using System;
using System.Text;
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
        private readonly ITokenService _tokenService;

        public UserRegistrationService(ApplicationDbContext dbContext, IEmailService emailService, ITokenService tokenService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
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
                    DateRegistration = DateTimeOffset.UtcNow,
                    LastLogin = DateTimeOffset.UtcNow,
                    IsActive = false,
                    PermissionUser = "Normal"
                };

                _dbContext.users.Add(user);
                await _dbContext.SaveChangesAsync();

                var mailRequest = _emailService.CreateWelcomeEmail(registrationDTO.Email);

                await _emailService.SendEmailAsync(mailRequest);

                
                var token = _tokenService.GenerateToken(registrationDTO.Email);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while registering user: {ex}");
                return false;
            }
        }

        public async Task<bool> ConfirmEmail(string token)
        {
            try
            {
                var decryptedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                var tokenParts = decryptedToken.Split(':');
                if (tokenParts.Length != 2)
                {
                    return false;
                }

                var email = tokenParts[0];
                var expirationTimeString = tokenParts[1];

                var expirationTime = DateTimeOffset.ParseExact(expirationTimeString, "yyyyMMddHHmmss", null);
                if (expirationTime < DateTimeOffset.UtcNow)
                {
                    return false;
                }

                var user = await _dbContext.users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
   
                    user.IsActive = true;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while confirming email: {ex}");
                return false;
            }
        }
    }
}
