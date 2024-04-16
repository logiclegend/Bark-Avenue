using BarkAvenueApi.Email;
using BarkAvenueApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            Mailrequest mailrequest = new Mailrequest();
            mailrequest.ToEmail = "logiclegends936@gmail.com";
            mailrequest.Subject = "Welcome to logiclegends";
            mailrequest.Body = "Registration is successful";
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
