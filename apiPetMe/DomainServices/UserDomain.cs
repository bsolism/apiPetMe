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

        public UserDomain() { }

        public UserDomain(DataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public User User(UserDto userDto, User user)
        {
            if (userDto.Name != null) user.Name = userDto.Name;
            if (userDto.Email != null) user.Email = userDto.Email;
            if (userDto.PhoneNumber != null) user.PhoneNumber = userDto.PhoneNumber;
            if (userDto.Image != null) user.Image = userDto.Image;
            if (userDto.Rol != 0) user.Rol = userDto.Rol;
            if (userDto.Password != null) user.Password = userDto.Password;
            if (userDto.Sal != null) user.Sal = userDto.Sal;


            return user;
        }
        public string isComplete(User user)
        {
            
            if(user.Name == null) return "Name Not Found";
            if(user.Email == null) return "Email Not Found";
            if(user.PhoneNumber == null) return "Phone Not Found";
            if(user.Password == null) return "Password Not Found";
            return "Complete";
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
