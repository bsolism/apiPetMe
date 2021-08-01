using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class LoginController :BaseController
    {
        private readonly IUnitOfWork uow;

        public LoginController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginReqDto loginReqDto)
        {
            var login = await uow.LoginApplication.Login(loginReqDto);
            if(login== null)
            {
                return BadRequest();
            }
            return Ok(login);
        }
    }
}
