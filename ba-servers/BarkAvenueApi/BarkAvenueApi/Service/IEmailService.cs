using BarkAvenueApi.Email;

namespace BarkAvenueApi.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mailrequest mailrequest);
    }
}

