using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IUserApplication
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> FindUser(string email);
        Task<IActionResult> AddUser(User User);
        Task<LoginResDto> UpdateUser(int id, UserDto userDto);
        Task<IActionResult> DeleteUser(string email);

    }
}
