using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Http;

namespace apiPetMe.Interface.Domain
{
    public interface IPetDomain
    {
        string Complete(PetDto pet);
        string UploadImage(IFormFile File);
    }
}
