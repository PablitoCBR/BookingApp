using BookingApp.Helpers;
using BookingApp.Entities.Accounts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace BookingApp.Security
{
    public class JWTProvider
    {
        private readonly AppSettings _appSettings;
        public JWTProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GetJWT(int id, string role)
        {
            JwtSecurityTokenHandler tokenHanlder = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                        )
            };

            SecurityToken token = tokenHanlder.CreateToken(tokenDescriptor);
            return tokenHanlder.WriteToken(token);
        }
    }
}
