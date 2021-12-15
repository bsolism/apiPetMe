using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Helper;
using apiPetMe.Interface.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class LoginApplication : ILoginApplication
    {
        
        private readonly IDomainUnitOfWork duow;

        public LoginApplication(IDomainUnitOfWork duow)
        {
           
            this.duow = duow;
        }
        public async Task<ObjectResult> Login(LoginReqDto loginReqDto)
        {
            var user = await duow.LoginDomainService.FindUser(loginReqDto.Email);

            if (user == null) return new ObjectResult("User Not Found") { StatusCode = 500 };
            var verification = Hash.CheckHash(loginReqDto.Password, user.Password, user.Sal);
            if (verification == false) return new ObjectResult("Error Password") { StatusCode = 500 };
            return new ObjectResult(new LoginResDto { Name = user.Name, Token = duow.CreateToken.CreateJWT(user) });
            
        }
   

    }
}
