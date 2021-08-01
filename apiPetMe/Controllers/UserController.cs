﻿using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Models;
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
        public Task<ActionResult<User>> GetById(string email)
        {
            var User = uow.UserApplication.FindUser(email);
            return User;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User User)
        {
            var activit = await uow.UserApplication.AddUser(User);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User User)
        {
            var user = await uow.UserApplication.UpdateUser(id, User);
            if (user == null)
            {
                return BadRequest();

            }
            return StatusCode(201);
        }
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var User = await uow.UserApplication.DeleteUser(email);
            if (User == null)
            {
                return BadRequest();
            }
            return StatusCode(201);
        }

    }
}
