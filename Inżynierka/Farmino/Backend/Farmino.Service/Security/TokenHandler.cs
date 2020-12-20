using Farmino.Service.DTO;
using Farmino.Service.Security.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Farmino.Service.Security
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _confgiuration;

        public TokenHandler(IConfiguration configuration)
        {
            _confgiuration = configuration;
        }

        public TokenDTO GenerateToken(UserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_confgiuration.GetSection("TokenSettings:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescription = new JwtSecurityToken
                (
                issuer: _confgiuration.GetSection("TokenSettings:Issuer").Value,
                claims: new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString())
                },
                expires: DateTimeOffset.Now.AddMinutes(Double.Parse(
                    _confgiuration.GetSection("TokenSettings:ExpireTime").Value)).DateTime,
                signingCredentials: credentials
                ); ;

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescription);

            return new TokenDTO
            {
                Token = token,
                GeneratedAt = DateTime.Now
            };
        }

        public TokenDTO RefreshToken(TokenDTO token)
        {
            throw new NotImplementedException();
        }
    }
}
