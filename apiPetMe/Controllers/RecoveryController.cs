using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class RecoveryController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IDomainUnitOfWork duow;

        public RecoveryController(IUnitOfWork uow, IDomainUnitOfWork duow)
        {
            this.uow = uow;
            this.duow = duow;
        }

        [HttpPost]
        public async Task<IActionResult> Recovery(LoginReqDto loginReqDto)
        {
            var tokenRecovery = await uow.RecoveryPassApplication.Recovery(loginReqDto.Email);
            if (tokenRecovery == null)
            {
                return BadRequest("Usuario no existe");
            }
            return Ok(tokenRecovery);
        }
        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(RecoveryPassDto dataRecovery)
        {
            HttpContext context = HttpContext;
            var message =  duow.RecoveryPassDomain.validatorRecovery(dataRecovery, context);
            if (message != "true") return BadRequest(message);


            return StatusCode(201);
            
        }
        
    }
}
