using apiPetMe.Interface;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public ClientController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Client>> GetTask()
        {
            return uow.ClientApplication.GetClient();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Client>> GetbyId(int id)
        {
            var client = uow.ClientApplication.FindClient(id);
            return client;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            var result = await uow.ClientApplication.AddClient(client);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client)
        {
            var result = await uow.ClientApplication.UpdateClient(id, client);
            if (result == null)
            {
                return BadRequest();
            }
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await uow.ClientApplication.DeleteClient(id);
            if (result == null)
            {
                return BadRequest();
            }
            return StatusCode(201);
        }


    }
}