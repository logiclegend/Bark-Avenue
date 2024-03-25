using System;
using System.Threading.Tasks;
using BarkAvenueApi.Helpter;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BarkAvenueApi.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }

        public async Task SendEmailAsync(Mailrequest mailrequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
            email.Subject = mailrequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailrequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
