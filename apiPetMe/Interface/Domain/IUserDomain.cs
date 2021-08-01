using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface IUserDomain
    {
        bool isComplete(User user);
        Task<User> FindUser(string email);
    }
}
