using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Application
{
    public interface IDonationApplication
    {
        Task<ObjectResult> Add(Donation donation);
    }
}
