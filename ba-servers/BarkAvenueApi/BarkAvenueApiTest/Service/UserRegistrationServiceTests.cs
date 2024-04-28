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
                Username = "user",
                Email = "test@example.com",
                Phone_number = "123456789",
                Password_user = "password",
                Confirm_password = "password"
            };

            var result = await userRegistrationService.RegisterUser(registrationDTO);

            result.Should().BeTrue();
            _context.users.Should().HaveCount(1);
        }

        [Fact]
        public async Task UserExists_UserAlreadyRegistered_ReturnsTrue()
        {
            var emailService = new MockEmailService();
            var userRegistrationService = new UserRegistrationService(_context, emailService);
            var registrationDTO = new RegistrationDTO
            {
                Username = "user",
                Email = "existing@example.com",
                Phone_number = "123456789",
                Password_user = "existingpassword",
                Confirm_password = "existingpassword"
            };
            await userRegistrationService.RegisterUser(registrationDTO);

            var result = await userRegistrationService.UserExists("existing@example.com");

            result.Should().BeTrue();
        }

        [Fact]
        public async Task RegisterUser_CorrectUserProperties()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var emailServiceMock = new Mock<IEmailService>();
                var registrationDTO = new RegistrationDTO
                {
                    Username = "user",
                    Email = "test@example.com",
                    Phone_number = "123456789",
                    Password_user = "password"
                };

                var userRegistrationService = new UserRegistrationService(context, emailServiceMock.Object);

                await userRegistrationService.RegisterUser(registrationDTO);
                var savedUser = await context.users.FirstOrDefaultAsync(u => u.Email == registrationDTO.Email);
                
                savedUser.Should().NotBeNull();
                savedUser.Username.Should().Be(registrationDTO.Username);
                savedUser.Email.Should().Be(registrationDTO.Email);
                savedUser.PhoneNumber.Should().Be(registrationDTO.Phone_number);
                savedUser.PasswordUser.Should().Be(registrationDTO.Password_user);
                savedUser.RoleUser.Should().Be("User");
                savedUser.PermissionUser.Should().Be("Normal");
                savedUser.IsActive.Should().BeFalse();
                savedUser.DateRegistration.Date.Should().BeCloseTo(DateTimeOffset.UtcNow.Date, TimeSpan.FromSeconds(1));
                savedUser.LastLogin.Date.Should().BeCloseTo(DateTimeOffset.UtcNow.Date, TimeSpan.FromSeconds(1));
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
