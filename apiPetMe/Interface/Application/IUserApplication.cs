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
        Task<ObjectResult> AddUser(User User);
        Task<ObjectResult> UpdateUser(int id, UserDto userDto);
        Task<ObjectResult> DeleteUser(string email);

    }
}
