using AuthTraining.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherForecast.Data.Models;
using WeatherForecastApi.Models;

namespace AuthTraining.Services
{
    public class JwtTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IConfiguration _config;

        public JwtTokenProvider(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
            {
                return string.Empty;
            }
            IdentityModelEventSource.ShowPII = true;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config[ApplicationSettingsConstants.JwtSecretKey]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("fullName", user.FullName.ToString()),
                new Claim("role", user.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
                Audience = _config[ApplicationSettingsConstants.JwtAudience],
                Issuer = _config[ApplicationSettingsConstants.JwtIssuer]
            }; 
            var securitytokenHandler = new JwtSecurityTokenHandler();
            var token = securitytokenHandler.CreateToken(tokenDescriptor);
            return securitytokenHandler.WriteToken(token);
        }
    }
}
