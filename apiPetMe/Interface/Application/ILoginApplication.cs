using apiPetMe.Dto;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface ILoginApplication
    {
        Task<LoginResDto> Login(LoginReqDto loginReqDto);
    }
}
