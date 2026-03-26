using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trainova.Application.Common.Interfaces;

namespace Trainova.Infrastructure.Identity
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string GenerateToken(Guid userId, string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(double.Parse(configuration["Jwt:AccessTokenExpirationMinutes"]!));

            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:ValidIssuer"],
            audience: configuration["Jwt:ValidAudience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credential
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
