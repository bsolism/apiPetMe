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
        [HttpGet("houseid/{id}")]
        public Task<IEnumerable<Pet>> GetByHouse(int id)
        {

            return uow.PetApplication.GetByHouseId(id);
        }
        [HttpGet("{id}")]
        public Task<Pet> GetById(int id)
        {
            var pet = uow.PetApplication.FindById(id);
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
    }
}
