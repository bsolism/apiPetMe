using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Helper;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
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

        public UserApplication(DataContext dc, IDomainUnitOfWork uow)
        {
            this.dc = dc;
            this.uow = uow;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await dc.Users.ToListAsync();
        }
        public async Task<ActionResult<User>> FindUser(string email)
        {
            User User = await uow.UserDomain.FindUser(email);
            if (User != null)
            {
                return User;
            }
            return null;

        }
        public async Task<IActionResult> AddUser(User user)
        {
            var isComplete = uow.UserDomain.isComplete(user);
            User findUser = await uow.UserDomain.FindUser(user.Email);
            if (isComplete && findUser == null)
            {
                var hash = Hash.Hashs(user.Password);
                user.Password = hash.Password;
                user.Sal = hash.Salt;
                dc.Users.Add(user);
                await dc.SaveChangesAsync();
                return new ObjectResult(user);
            }
            return null;
        }
        public async Task<ActionResult> UpdateUser(int id, User User)
        {
            if (id != User.ClientId)
            {
                return null;

            }
            dc.Entry(User).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteUser(string email)
        {
            User User = await uow.UserDomain.FindUser(email);
            if (User == null)
            {
                return null;
            }
            dc.Users.Remove(User);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}
