using BarkAvenueApi.Models;
using BarkAvenueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _registrationService;
        private readonly ITokenService _tokenService;

        public UserRegistrationController(IUserRegistrationService registrationService, ITokenService tokenService)
        {
            _registrationService = registrationService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDTO registrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registrationService.RegisterUser(registrationDTO);

            if (result)
            {
                var token = _tokenService.GenerateToken(registrationDTO.Email);

                return Ok(new { Token = token, Message = "User registered successfully!" });
            }
            else
            {
                return BadRequest("User registration failed.");
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is required.");
            }

            var isEmailConfirmed = await _registrationService.ConfirmEmail(token);

            if (isEmailConfirmed)
            {
                return Ok("Email confirmed successfully!");
            }
            else
            {
                return BadRequest("Email confirmation failed.");
            }
        }
    }
}
