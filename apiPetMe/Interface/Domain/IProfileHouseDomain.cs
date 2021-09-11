using apiPetMe.Dto;
using apiPetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface IProfileHouseDomain
    {
        string isComplete(ProfileHouseDto profileHouseDto);
        ProfileHouseDto UploadImage(ProfileHouseDto profileHouseDto);
        ProfileHouse ProfileHouse(ProfileHouseDto profileHouseDto, ProfileHouse profileHouse);
    }
}
