using BarkAvenueApi.Models;
using BarkAvenueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _registrationService;

        public RegistrationController(IUserRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDTO registrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registrationService.RegisterUser(registrationDTO);

            if (result)
            {
                return Ok("User registered successfully!");
            }
            else
            {
                return BadRequest("User registration failed.");
            }
        }
    }
}
