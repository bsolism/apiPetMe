using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Helper;
using apiPetMe.Interface.Application;
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
        public async Task<LoginResDto> Login(LoginReqDto loginReqDto)
        {
            var user = await duow.LoginDomainService.FindUser(loginReqDto.Email);

            if (user == null)
            {
                return null;
            }
            var verification = Hash.CheckHash(loginReqDto.Password, user.Password, user.Sal);
            if (verification == false)
            {
                return null;
            }
            return new LoginResDto { Name = user.Name, Token = duow.CreateToken.CreateJWT(user) };
            
        }
   

    }
}
