using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace apiPetMe.Interface.Domain
{
    public interface IPetDomain
    {
        string Complete(PetDto pet);
        string UploadImage(IFormFile File);
        bool updateImage(int id, PetDto petDto, List<PetPhotos> petPhotos);
        Pet Pet(PetDto petDto, Pet pet);
    }
}
