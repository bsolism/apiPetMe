using apiPetMe.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface IRecoveryPassDomain
    {
        string validatorRecovery(RecoveryPassDto dataRecovery, HttpContext session);
    }
}
