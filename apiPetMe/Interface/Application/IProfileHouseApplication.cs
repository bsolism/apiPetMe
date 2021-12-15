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
        Task<IEnumerable<ProfileHouse>> GetHouseByUserId(int id);
        Task<ProfileHouse> FindProfileHouse(int id);
        Task<ObjectResult> AddHouse(ProfileHouseDto profileHouseDto);
        Task<ObjectResult> Update(int id, ProfileHouseDto profileHouseDto);
        Task<ObjectResult> Delete(int id);
    }
}
