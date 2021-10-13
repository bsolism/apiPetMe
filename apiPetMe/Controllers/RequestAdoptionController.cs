using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class RequestAdoptionController:  BaseController
    {
        private readonly IUnitOfWork uow;

        public RequestAdoptionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<RequestAdoption>> Get()
        {

            return uow.RequestAdoptionApplication.Get();
        }
        [HttpGet("house/{id}")]
        public Task<IEnumerable<RequestAdoption>> GetByHouse(int id)
        {

            return uow.RequestAdoptionApplication.FindByHouse(id);
        }
        [HttpGet("{id}")]
        public Task<RequestAdoption> GetById(int id)
        {
            return uow.RequestAdoptionApplication.FindById(id);
           
        }
        [HttpGet("user/{id}")]
        public Task<IEnumerable<RequestAdoption>> GetByUserId(int id)
        {
            return uow.RequestAdoptionApplication.FindByUserId(id);

        }
        [HttpPost]
        public async Task<IActionResult> Add(RequestAdoption requestAdoption)
        {
            var data = await uow.RequestAdoptionApplication.Add(requestAdoption);

            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [ActionName("GetById")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RequestAdoption requestAdoption)
        {
            var data = await uow.RequestAdoptionApplication.Update(id, requestAdoption);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);

            }

            return CreatedAtAction(nameof(GetById), new { requestAdoption.RequestAdoptionId }, data.Value);


        }
    }
}
