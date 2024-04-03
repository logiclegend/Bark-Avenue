using BarkAvenueApi.Email;

namespace BarkAvenueApi.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mailrequest mailrequest);
    }
}

