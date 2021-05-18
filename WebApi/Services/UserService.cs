using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Response result(AuthRequest model)
        {
            Response result = new Response();

            if (model.Usuario == "jucava86" && model.Password == "string")
            {
                result.Success = true;
                result.Message = "correcto";
                result.Data = GetToken(model);
            }
            else
            {
                result.Success = false;
                result.Message = "error";
                result.Data = "";
            }
            return result;
        }

        private string GetToken(AuthRequest model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Usuario.ToString()),
                        new Claim(ClaimTypes.Email, model.Password.ToString())
                    }
                    ),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
