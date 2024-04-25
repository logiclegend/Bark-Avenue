using Microsoft.AspNetCore.Mvc;
using BarkAvenueApi.Services;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;

        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }

            var (isAuthenticated, token, error) = await _authenticationService.AuthenticateAsync(model.Username, model.Password);

            if (isAuthenticated)
            {
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(error);
            }
        }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
