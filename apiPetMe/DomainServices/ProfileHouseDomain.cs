using apiPetMe.Context;
using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace apiPetMe.DomainServices
{
    public class ProfileHouseDomain : IProfileHouseDomain
    {
        private readonly DataContext dc;
        private readonly IWebHostEnvironment environment;

        public ProfileHouseDomain(DataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public string isComplete(ProfileHouseDto profileHouseDto)
        {
            if (profileHouseDto.Name == null) return "Name not found";
            if (profileHouseDto.City == null) return "City not found";
            if (profileHouseDto.Address == null) return "Address not found";
            if (profileHouseDto.Phone == null) return "Phone not found";
            if (profileHouseDto.Email == null) return "Email not found";
            if (profileHouseDto.UserId == 0) return "Id User not found";
            return "Complete";
        }
        public ProfileHouseDto UploadImage(ProfileHouseDto profileHouseDto)
        {
            string guidImagen;
            if (profileHouseDto.File != null)
            {
                if (!Directory.Exists(environment.WebRootPath + "\\HouseImageProfile\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\HouseImageProfile\\");
                }
                string fichero = Path.Combine(environment.WebRootPath, "HouseImageProfile");
                guidImagen = Guid.NewGuid().ToString() + profileHouseDto.File.FileName;
                string url = Path.Combine(fichero, guidImagen);
                profileHouseDto.File.CopyTo(new FileStream(url, FileMode.Create));

                profileHouseDto.Image = guidImagen;


                return profileHouseDto;
            }

            return profileHouseDto;
        }
    }
}
