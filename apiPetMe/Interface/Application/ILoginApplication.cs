using apiPetMe.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface ILoginApplication
    {
        Task<ObjectResult> Login(LoginReqDto loginReqDto);
    }
}
