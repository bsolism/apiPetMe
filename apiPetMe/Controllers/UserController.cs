using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;

        public UserController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
       
        [HttpGet]
        public Task<IEnumerable<User>> GetUser()
        {
            
            return uow.UserApplication.GetUser();
        }
        [HttpGet("{email}")]
        public Task<User> GetById(string email)
        {
            var User = uow.UserApplication.FindUser(email);
            return User;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var data = await uow.UserApplication.AddUser(user);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] UserDto userDto)
        {
            var user = await uow.UserApplication.UpdateUser(id, userDto);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }
            
            return Ok(user.Value);
        }
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var User = await uow.UserApplication.DeleteUser(email);
            if (User.StatusCode == 500)
            {
                return BadRequest(User.Value);
            }
            return StatusCode(200);
        }

    }
}
