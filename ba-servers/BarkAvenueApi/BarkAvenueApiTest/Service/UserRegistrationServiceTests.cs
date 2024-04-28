using System;
using System.Threading.Tasks;
using BarkAvenueApi.Email;
using BarkAvenueApi.Models;
using BarkAvenueApi.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BarkAvenueApi.Tests
{
    public class UserRegistrationServiceTests : IDisposable
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;

        public UserRegistrationServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;
            _context = new ApplicationDbContext(_options);
        }

        [Fact]
        public async Task RegisterUser_ValidData_ReturnsTrue()
        {
            var emailService = new MockEmailService();
            var userRegistrationService = new UserRegistrationService(_context, emailService);
            var registrationDTO = new RegistrationDTO
            {
                Username = "testuser",
                Email = "test@example.com",
                Phone_number = "1234567890",
                Password_user = "testpassword",
                Confirm_password = "testpassword"
            };

            var result = await userRegistrationService.RegisterUser(registrationDTO);

            Assert.True(result);
            Assert.Equal(1, await _context.users.CountAsync());
        }

        [Fact]
        public async Task UserExists_UserAlreadyRegistered_ReturnsTrue()
        {
            var emailService = new MockEmailService();
            var userRegistrationService = new UserRegistrationService(_context, emailService);
            var registrationDTO = new RegistrationDTO
            {
                Username = "existinguser",
                Email = "existing@example.com",
                Phone_number = "1234567890",
                Password_user = "existingpassword",
                Confirm_password = "existingpassword"
            };
            await userRegistrationService.RegisterUser(registrationDTO);

            var result = await userRegistrationService.UserExists("existing@example.com");

            Assert.True(result);
        }

        [Fact]
        public async Task RegisterUser_CorrectUserProperties()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var emailServiceMock = new Mock<IEmailService>();
                var registrationDTO = new RegistrationDTO
                {
                    Username = "testuser",
                    Email = "test@example.com",
                    Phone_number = "123456789",
                    Password_user = "password"
                };

                var userRegistrationService = new UserRegistrationService(context, emailServiceMock.Object);

                await userRegistrationService.RegisterUser(registrationDTO);
                var savedUser = await context.users.FirstOrDefaultAsync(u => u.Email == registrationDTO.Email);

                Assert.NotNull(savedUser);
                Assert.Equal(registrationDTO.Username, savedUser.Username);
                Assert.Equal(registrationDTO.Email, savedUser.Email);
                Assert.Equal(registrationDTO.Phone_number, savedUser.PhoneNumber);
                Assert.Equal(registrationDTO.Password_user, savedUser.PasswordUser);
                Assert.Equal("User", savedUser.RoleUser);
                Assert.Equal("Normal", savedUser.PermissionUser);
                Assert.False(savedUser.IsActive);
                Assert.Equal(DateTimeOffset.UtcNow.Date, savedUser.DateRegistration.Date);
                Assert.Equal(DateTimeOffset.UtcNow.Date, savedUser.LastLogin.Date);
            }
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
    public class MockEmailService : IEmailService
    {
        public Mailrequest CreateWelcomeEmail(string email)
        {
            return new Mailrequest
            {
                ToEmail = email,
                Subject = "Welcome to Our Website",
                Body = "Thank you for registering on our website!"
            };
        }

        public Task SendEmailAsync(Mailrequest mailrequest)
        {
            return Task.CompletedTask;
        }
    }
}
