using apiPetMe.Context;
using apiPetMe.Dto;
using apiPetMe.Helper;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.DomainServices
{
    public class LoginDomainService : ILoginDomainService
    {
        private readonly DataContext dc;

        public LoginDomainService(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<User> FindUser(string email)
        {
            var user= await dc.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user== null)
            {
                return null;
            }
           
            return user;

        }
    }
}
