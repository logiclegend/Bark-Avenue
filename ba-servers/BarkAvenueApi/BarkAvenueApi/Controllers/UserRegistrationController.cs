using Microsoft.AspNetCore.Mvc;
using BarkAvenueApi.Models;
using BarkAvenueApi.Services;
using System;
using System.Threading.Tasks;

namespace BarkAvenueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UserController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if user already exists
            if (await _userRegistrationService.UserExists(user.username))
            {
                return Conflict("User with this username already exists");
            }

            // Set default values
            user.role_user = "User";
            user.date_registration = DateTime.Now;
            user.is_active = true;
            user.permission_user = "Default";

            // Save user to the database
            var result = await _userRegistrationService.RegisterUser(user);

            if (result.Success)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return StatusCode(500, "Failed to register user");
            }
        }
    }
}

