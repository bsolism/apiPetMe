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
        Task<ActionResult<User>> FindUser(string email);
        Task<IActionResult> AddUser(User User);
        Task<ActionResult> UpdateUser(int id, User User);
        Task<IActionResult> DeleteUser(string email);

    }
}
