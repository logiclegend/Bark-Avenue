//// UserRegistrationServiceMarta.cs

//using System;
//using System.Threading.Tasks;
//using BarkAvenueApi.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BarkAvenueApi.Services
//{
//    public class UserRegistrationServiceMarta : IUserRegistrationServiceMarta
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public UserRegistrationServiceMarta(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
//        }

//        public async Task<bool> UserExists(string email)
//        {
//            try
//            {
//                return await _dbContext.users.AnyAsync(u => u.email == email);
//            }
//            catch (Exception ex)
//            {
//                // Обробка помилок під час перевірки існування користувача
//                Console.WriteLine($"Помилка при перевірці існування користувача: {ex}");
//                return false;
//            }
//        }

//        public async Task<bool> RegisterUser(User user)
//        {
//            try
//            {
//                if (await UserExists(user.email))
//                {
//                    return false;
//                }

//                var registrationDTO = new RegistrationDTO
//                {
//                    Username = user.username,
//                    Email = user.email,
//                    Phone_number = user.phone_number,
//                    Password_user = user.password_user,
//                    Confirm_password = user.password_user // Підтвердження пароля
//                };

//                var result = await RegisterUser(registrationDTO);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                // Обробка помилок під час реєстрації користувача
//                Console.WriteLine($"Помилка при реєстрації користувача: {ex}");
//                return false;
//            }
//        }

//        public async Task<bool> RegisterUser(RegistrationDTO registrationDTO)
//        {
//            try
//            {
//                var user = new User
//                {
//                    username = registrationDTO.Username,
//                    email = registrationDTO.Email,
//                    phone_number = registrationDTO.Phone_number,
//                    password_user = registrationDTO.Password_user,
//                    role_user = "User",
//                    date_registration = DateTimeOffset.UtcNow,
//                    last_login = DateTimeOffset.UtcNow,
//                    is_active = false,
//                    permission_user = "Normal"
//                };

//                _dbContext.users.Add(user);
//                await _dbContext.SaveChangesAsync();

//                return true;
//            }
//            catch (Exception ex)
//            {
//                // Обробка помилок під час реєстрації користувача
//                Console.WriteLine($"Помилка при реєстрації користувача: {ex}");
//                return false;
//            }
//        }
//    }
//}


// UserRegistrationServiceMarta.cs

using System;
using System.Threading.Tasks;
using BarkAvenueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Services
{
    public class UserRegistrationServiceMarta : IUserRegistrationServiceMarta
    {
        private readonly ApplicationDbContext _dbContext;

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
                    return false;
                }

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

                _dbContext.users.Add(user);
                await _dbContext.SaveChangesAsync();

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
