using System.Threading.Tasks;
using BarkAvenueApi.Email;
using BarkAvenueApi.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace BarkAvenueApi.Tests.Services
{
    public class EmailServiceTests
    {
        [Fact]
        public async Task SendEmailAsync_Sends_Email_Successfully()
        {
            var emailSettings = new EmailSettings
            {
                Email = "logiclegends936@gmail.com",
                Password = "bvtmkajyyaewxbeo",
                Host = "smtp.gmail.com",
                Port = 587
            };

            var optionsMock = new Mock<IOptions<EmailSettings>>();
            optionsMock.Setup(opt => opt.Value).Returns(emailSettings);

            var emailService = new EmailService(optionsMock.Object);
            var mailRequest = new Mailrequest
            {
                ToEmail = "user@example.com",
                Subject = "Test Subject",
                Body = "Test Body"
            };

            await emailService.SendEmailAsync(mailRequest);
        }

        [Fact]
        public async Task SendEmailAsync_Fails_With_Invalid_MailRequest()
        {
            var emailSettings = new EmailSettings
            {
                Email = "user@example.com",
                Password = "password",
                Host = "smtp.example.com",
                Port = 587
            };

            var optionsMock = new Mock<IOptions<EmailSettings>>();
            optionsMock.Setup(opt => opt.Value).Returns(emailSettings);

            var emailService = new EmailService(optionsMock.Object);
            var invalidMailRequest = new Mailrequest
            {
                ToEmail = "", 
                Subject = "Test Subject",
                Body = "Test Body"
            };

            await Assert.ThrowsAsync<MimeKit.ParseException>(() => emailService.SendEmailAsync(invalidMailRequest));
        }

        [Fact]
        public async Task SendEmailAsync_Fails_With_Invalid_Email_Settings()
        {
            var invalidEmailSettings = new EmailSettings
            {
                Email = null,
                Password = null,
                Host = null,
                Port = 0
            };

            var optionsMock = new Mock<IOptions<EmailSettings>>();
            optionsMock.Setup(opt => opt.Value).Returns(invalidEmailSettings);

            var emailService = new EmailService(optionsMock.Object);

            var mailRequest = new Mailrequest
            {
                ToEmail = "user@example.com",
                Subject = "Test Subject",
                Body = "Test Body"
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => emailService.SendEmailAsync(mailRequest));
        }


    }
}
