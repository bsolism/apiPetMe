using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Helper;
using apiPetMe.Interface.Application;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class LoginApplication : ILoginApplication
    {
        private readonly LoginResDto loginResDTO;
        private readonly IDomainUnitOfWork duow;

        public LoginApplication(LoginResDto loginResDTO, IDomainUnitOfWork duow)
        {
            this.loginResDTO = loginResDTO;
            this.duow = duow;
        }
        public async Task<LoginResDto> Login(LoginReqDto loginReqDto)
        {
            var user = await duow.LoginDomainService.FindUser(loginReqDto);

            if (user == null)
            {
                return null;
            }
            var verification = Hash.CheckHash(loginReqDto.Password, user.Password, user.Sal);
            if (verification == false)
            {
                return null;
            }
            loginResDTO.Name = user.Name;
            loginResDTO.Token = duow.CreateToken.CreateJWT(user);
            return loginResDTO;
        }

    }
}
