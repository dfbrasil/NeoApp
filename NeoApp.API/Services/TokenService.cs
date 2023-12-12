using Microsoft.IdentityModel.Tokens;
using NeoApp.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NeoApp.API.Services
{
    public class TokenService
    {
        public static object GenerateToken(int id, string userType)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            var role = userType == "Paciente" ? "Paciente" : "Medico";

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", id.ToString()),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString,
            };
        }
    }
}
