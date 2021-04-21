using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using Auth.Contracts;
using Repository.DTO;

namespace BearerAuthenticationApi.Auth
{
    public class TokenService : ITokenService
    {
        private IConfiguration _conf { get; }
        public TokenService(IConfiguration configuration)
        {
            _conf = configuration;
        }

        public string GenerateToken(LoginDTO login)
        {
            var tokenHendler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_conf.GetValue<string>("Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Username.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, login.idUser.ToString())
                     //new Claim(ClaimTypes., login.Username.ToString()),
                    //new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHendler.CreateToken(tokenDescriptor);

            return tokenHendler.WriteToken(token);
        }
    }
}