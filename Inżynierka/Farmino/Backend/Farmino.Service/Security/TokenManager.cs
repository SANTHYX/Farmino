using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Token;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Security.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Farmino.Service.Security
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _configuration;
        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RefreshTokenModel GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("Security:Key").Value));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expirationTime = Double.Parse(_configuration.GetSection("Security:ExpireTime").Value);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString())
                }),
                SigningCredentials = credentials,
                Expires= DateTime.Now.AddMinutes(expirationTime),
                NotBefore = DateTime.Now
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = new JwtSecurityTokenHandler().CreateToken(descriptor);

            var refreshToken = new RefreshToken(
                Guid.Parse(createdToken.Id), GenerateRefresh(), user, expirationTime);

            var token = new TokenDTO
            {
                Token = tokenHandler.WriteToken(createdToken),
                Refresh = refreshToken.Token,
                ExpiresAt = refreshToken.GeneratedAt
            };

            return new RefreshTokenModel
            {
                Token = token,
                RefreshToken = refreshToken
            };
        }
        private string GenerateRefresh()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
