using apiPetMe.Dto;
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
    }
}
