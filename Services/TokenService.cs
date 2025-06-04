﻿using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CustomerAPIv1.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) { _config = config; }

        public string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
