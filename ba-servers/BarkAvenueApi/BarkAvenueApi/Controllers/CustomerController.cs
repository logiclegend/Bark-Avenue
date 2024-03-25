using BarkAvenueApi.Helpter;
using BarkAvenueApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarkAvenueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEmailService emailService;

        public CustomerController(IEmailService service)
        {
            this.emailService = service;
        }

        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                //var mailrequest = new Mailrequest("logiclegends936@gmail.com", "Welcome to our site!", "Verification code...");
                Mailrequest mailrequest = new Mailrequest();
                mailrequest.ToEmail = "logiclegends936@gmail.com";
                mailrequest.Subject = "Welcome to our site!";
                mailrequest.Body = "Verification code...";
                await emailService.SendEmailAsync(mailrequest);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
