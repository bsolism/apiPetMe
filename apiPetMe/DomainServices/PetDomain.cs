using apiPetMe.Context;
using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace apiPetMe.DomainServices
{
    public class PetDomain : IPetDomain
    {
        private readonly DataContext dc;
        private readonly IWebHostEnvironment environment;

        public PetDomain(DataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public string Complete(PetDto pet)
        {
            if (pet.Name == null) return "Name not found";
            if (pet.Category == null) return "Category not found";
            if (pet.Description == null) return "Description not found";
            if (pet.Old == 0) return "Old not found";
            if (pet.Weight == null) return "Weight not found"; 
            if (pet.Height == null) return "Height not found"; 
            if (pet.Sex == null) return "Sex not found"; 
            if (pet.Color == null) return "Color not found"; 
            if (pet.ProfileHouseId == 0) return "Profile Id not found";
            if (pet.File == null) return "Image not found";

            return "Complete";
        }
        public string UploadImage(IFormFile File)
        {
            string guidImagen=null;
            if (File != null)
            {
                if (!Directory.Exists(environment.WebRootPath + "\\ImagePet\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\ImagePet\\");
                }
                string fichero = Path.Combine(environment.WebRootPath, "ImagePet");
                guidImagen = Guid.NewGuid().ToString() + File.FileName;
                string url = Path.Combine(fichero, guidImagen);
                File.CopyTo(new FileStream(url, FileMode.Create));

                return guidImagen;
            }

            return guidImagen;
        }
    }
}
