using AlliantProductManagementServer.Application.Security;
using AlliantProductManagementServer.Domain.Entities.Users;
using Jose;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Utils
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;
        public AuthHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = Convert.FromBase64String(_configuration.GetValue<string>("JwtSettings:secretKey")!);
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSettings:secretKey")!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "user-id"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                Issuer = _configuration.GetValue<string>("JwtSettings:issuer"),
                Audience = _configuration.GetValue<string>("JwtSettings:audience"),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            return JWT.Encode(plainText, _key, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
        }
        public string Decrypt(string encryptedText)
        {

            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));

            return JWT.Decode(encryptedText, _key);
        }
    }
}
