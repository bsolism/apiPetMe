using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IProfileHouseApplication
    {
        Task<IEnumerable<ProfileHouse>> GetHouse();
        Task<ProfileHouse> FindProfileHouse(string email);
        Task<ObjectResult> AddHouse(ProfileHouseDto profileHouseDto);
    }
}
