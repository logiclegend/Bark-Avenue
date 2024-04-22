using BarkAvenueApi.Email;

namespace BarkAvenueApi.Services
{
    public interface IEmailService
    {
        Mailrequest CreateWelcomeEmail(string email);
        Task SendEmailAsync(Mailrequest mailrequest);
    }
}

