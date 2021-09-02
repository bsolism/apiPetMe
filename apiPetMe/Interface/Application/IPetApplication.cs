using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IPetApplication
    {
        Task<IEnumerable<Pet>> Get();
        Task<Pet> FindById(int id);
        Task<ObjectResult> Add(PetDto petDto);
    }
}
