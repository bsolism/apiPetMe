using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class ProfileHouseController :  BaseController
    {
        private readonly IUnitOfWork uow;

        public ProfileHouseController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<ProfileHouse>> GetUser()
        {

            return uow.ProfileHouseApplication.GetHouse();
        }
        [HttpGet("{id}")]
        public Task<ProfileHouse> GetById(int id)
        {
            var profileHouse = uow.ProfileHouseApplication.FindProfileHouse(id); 
            return profileHouse;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProfileHouseDto profileHouseDto)
        {
            var data = await uow.ProfileHouseApplication.AddHouse(profileHouseDto);
            
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [ActionName("GetById")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ProfileHouseDto profileHouseDto)
        {
            var data = await uow.ProfileHouseApplication.Update(id, profileHouseDto);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);

            }

            return CreatedAtAction(nameof(GetById), new {profileHouseDto.ProfileId }, data.Value);

            
        }
    }
}
