using apiPetMe.Dto;
using apiPetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface ILoginDomainService
    {
        Task<User> FindUser(string email);
    }
}
