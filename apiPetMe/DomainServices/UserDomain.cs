using apiPetMe.Context;
using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace apiPetMe.DomainServices
{
    public class UserDomain : IUserDomain
    {
        private readonly DataContext dc;
        private readonly IWebHostEnvironment environment;

        public UserDomain(DataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public bool isComplete(User user)
        {
            
            if(user.Name == null) return false;
            if(user.Email == null) return false;
            if(user.PhoneNumber == null) return false;
            if(user.Password == null) return false;
            return true;
        }
        public UserDto UploadImage(UserDto userDto)
        {
            string guidImagen;
            if (userDto.File != null)
            {
                if (!Directory.Exists(environment.WebRootPath + "\\UserImageProfile\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\UserImageProfile\\");
                }
                string fichero = Path.Combine(environment.WebRootPath, "UserImageProfile");
                guidImagen = Guid.NewGuid().ToString() + userDto.File.FileName;
                string url = Path.Combine(fichero, guidImagen);
                userDto.File.CopyTo(new FileStream(url, FileMode.Create));

                userDto.Image = guidImagen;


                return userDto;
            }

            return userDto;
        }



    }
}
