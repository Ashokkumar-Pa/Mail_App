using Mail_App.IServices;
using Mail_App.ResponseModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mail_App.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IConfiguration config;

        public AuthenticationManager(IConfiguration _config)
        {
            config = _config;
        }
        public string GetToken(UserTokenModel userDate)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(config["Jwt:ProviderKey"]);

                var tokenData = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userDate.Name),
                    new Claim(ClaimTypes.Email, userDate.EmailAddress),
                    new Claim(ClaimTypes.SerialNumber, userDate.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(0.5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenData);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
