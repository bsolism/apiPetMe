using apiPetMe.Dto;
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
        private SymmetricSecurityKey Key()
        {
            var secretKey = configuration["AppSettings:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));
            return key;
        }
        private SigningCredentials SigningCredentials(SymmetricSecurityKey key)
        {
            return  new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );
        }

        public string CreateJWT(User user)
        {
            var key = Key();
            var claims = new Claim[]{
                new Claim("name", user.Name),
                new Claim("userId", user.UserId.ToString()),
                new Claim("email", user.Email),
                new Claim("rol", user.Rol.ToString()),
                new Claim("password", user.Password),
                new Claim("phoneNumber", user.PhoneNumber),
                new Claim("image", (user.Image==null)?"null": user.Image)
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
        public string TokenRecovery(RecoveryPassDto recoveryPassDto)
        {
            var key = Key();
            var claims = new Claim[]{
                new Claim("email", recoveryPassDto.Email),
                new Claim("code", recoveryPassDto.Code)
            };
            var signingCredentials = SigningCredentials(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
