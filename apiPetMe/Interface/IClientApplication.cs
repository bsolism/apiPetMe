using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.Interface
{
    public interface IClientApplication
    {
        Task<IEnumerable<Client>> GetClient();
        Task<ActionResult<Client>> FindClient(int id);
        Task<IActionResult> AddClient(Client client);
        Task<ActionResult> UpdateClient(int id, Client client);
        Task<IActionResult> DeleteClient(int id);
    }
}