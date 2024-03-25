using BarkAvenueApi.Helpter;

namespace BarkAvenueApi.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mailrequest mailrequest);
    }
}
