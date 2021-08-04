using apiPetMe.Interface.Domain;
using apiPetMe.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiPetMe.DomainServices
{
    public class CreateToken :ICreateToken
    {
        private readonly IConfiguration configuration;

        public CreateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJWT(User user)
        {
            var secretKey = configuration["AppSettings:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("email", user.Email),
                new Claim("phoneNumber", user.PhoneNumber)
            };
            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(180),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
