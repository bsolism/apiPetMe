using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IRequestAdoptionApplication
    {
        Task<IEnumerable<RequestAdoption>> Get();
        Task<IEnumerable<RequestAdoption>> FindByHouse(int id);
        Task<RequestAdoption> FindById(int id);
        Task<ObjectResult> Add(RequestAdoption requestAdoption);
    }
}
