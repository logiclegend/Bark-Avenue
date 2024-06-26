﻿using Microsoft.EntityFrameworkCore;
using BarkAvenueApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BarkAvenueApi.Services
{
    public interface IUserAuthenticationService
    {
        Task<(bool, string, string)> AuthenticateAsync(string username, string password);
    }

    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public UserAuthenticationService(ApplicationDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        public async Task<(bool, string, string)> AuthenticateAsync(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordUser == password);

            if (user == null)
            {
                return (false, null, "Invalid username or password.");
            }

            if (!IsUserAuthorized(user))
            {
                return (false, null, "User is not authorized.");
            }

            var token = GenerateJwtToken(user);

            return (true, token.ToString(), null);
        }
        private bool IsUserAuthorized(User user)
        {
            return user.RoleUser == "user"; 
        }
        private JwtSecurityToken GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RoleUser)
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiryInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.CreateToken(tokenDescriptor) as JwtSecurityToken;
        }
    }
}
