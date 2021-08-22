using apiPetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IRecoveryPassApplication
    {
        Task<string> Recovery(string email);
    }
}
