using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Context;
using apiPetMe.DomainServices;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class RecoveryPassApplication : IRecoveryPassApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork duow;

        public RecoveryPassApplication(DataContext dc, IDomainUnitOfWork duow)
        {
            this.dc = dc;
            this.duow = duow;
        }
        private async Task<User> FindUser(string email)
        {
            var User = await dc.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (User != null)
            {
                return User;
            }
            return null;

        }
        public async Task<string> Recovery(string email)
        {
            var user = await FindUser(email);
            if (user == null) return null;

            Random rnd = new Random();
            int code = rnd.Next(100000, 999999);
            await duow.EmailSender.SendEmailAsync(email, code.ToString()).ConfigureAwait(false);

            var dataRecovery = new RecoveryPassDto { Email = email, Code = code.ToString() };

            return duow.CreateToken.TokenRecovery(dataRecovery);
        }
        public async Task<ActionResult> UpdateRecovery(int id, User User)
        {
            if (id != User.UserId)
            {
                return null;

            }
            dc.Entry(User).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }

    }
}
