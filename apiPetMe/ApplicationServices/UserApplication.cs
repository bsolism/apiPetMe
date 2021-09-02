using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Helper;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class UserApplication : IUserApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork uow;
        private readonly IMapper mapper;

        public UserApplication(DataContext dc, IDomainUnitOfWork uow, IMapper mapper)
        {
            this.dc = dc;
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await dc.Users.ToListAsync();
        }
        public async Task<User> FindUser(string email)
        {
            var User = await dc.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (User != null)
            {
                return User;
            }
            return null;

        }
        public async Task<ObjectResult> AddUser(User user)
        {
            var isComplete = uow.UserDomain.isComplete(user);
            if (isComplete != "Complete") return new ObjectResult(isComplete) { StatusCode = 500 };
            var findUser = FindUser(user.Email);
            if (findUser.Result == null)
            {
                var hash = Hash.Hashs(user.Password);
                user.Password = hash.Password;
                user.Sal = hash.Salt;
                dc.Users.Add(user);
                await dc.SaveChangesAsync();
                return new ObjectResult(user);
            }
            return new ObjectResult("User already exists") {StatusCode= 500 };
        }
        public async Task<ObjectResult> UpdateUser(int id, UserDto userDto)
        {
            var userMap = await dc.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == userDto.Email);
            if (userMap == null) return new ObjectResult("not allowed to change the email") { StatusCode = 500 };
            if (id != userDto.UserId) return new ObjectResult("Id not Match") { StatusCode = 500 };
            uow.UserDomain.UploadImage(userDto);
            if (userDto.Password != null)
            {
                var hash = Hash.Hashs(userDto.Password);
                userDto.Password = hash.Password;
                userDto.Sal = hash.Salt;

            }
            userMap = uow.UserDomain.User(userDto, userMap);
            dc.Entry(userMap).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            if (res == 0) return new  ObjectResult("Save failed") {StatusCode= 500};
            return new ObjectResult(new LoginResDto { Name = userMap.Name, Token = uow.CreateToken.CreateJWT(userMap) }) {StatusCode= 200 };
        }
        public async Task<ObjectResult> DeleteUser(string email)
        {
            var User = await FindUser(email);
            if (User == null)
            {
                return new ObjectResult("User not found") {StatusCode= 500 };
            }
           
            dc.Users.Remove(User);
            await dc.SaveChangesAsync();
            return new ObjectResult("User deleted") {StatusCode=200 };
        }
    }
}
