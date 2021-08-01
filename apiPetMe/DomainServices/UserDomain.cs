using apiPetMe.Context;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace apiPetMe.DomainServices
{
    public class UserDomain : IUserDomain
    {
        private readonly DataContext dc;

        public UserDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public bool isComplete(User user)
        {
            
            if(user.Name == null) return false;
            if(user.Email == null) return false;
            if(user.PhoneNumber == null) return false;
            if(user.Password == null) return false;
            return true;
        }
        public async Task<User> FindUser(string email)
        {
            User User = await dc.Users.FirstOrDefaultAsync(x => x.Email== email);
            return User;
        }
        

    }
}
