using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class PetController:  BaseController
    {
        private readonly IUnitOfWork uow;

        public PetController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Pet>> Get()
        {

            return uow.PetApplication.Get();
        }
     
        [HttpGet("{id}")]
        public Task<Pet> GetById(int id)
        {
            var pet = uow.PetApplication.FindById(id);
            return pet;
        }
        [HttpGet("houseId/{id}")]
        public Task<IEnumerable<Pet>> GetByHouseId(int id)
        {
            var pet = uow.PetApplication.FindByHouseId(id);
            return pet;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PetDto petDto)
        {
            var data = await uow.PetApplication.Add(petDto);
            if(data.StatusCode== 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] PetDto petDto)
        {
            var user = await uow.PetApplication.Update(id, petDto);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
