using apiPetMe.Context;
using apiPetMe.Interface;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class ClientApplication : IClientApplication
    {
        private readonly DataContext dc;
        private readonly IClientDomainService cds;
        public ClientApplication(DataContext dc, IClientDomainService cds)
        {
            this.cds = cds;
            this.dc = dc;

        }

        public async Task<IEnumerable<Client>> GetClient()
        {
            return await dc.Clients.ToListAsync();
        }
        public async Task<ActionResult<Client>> FindClient(int id)
        {
            var client = await dc.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client != null)
            {
                return client;
            }
            return null;
        }
        public async Task<IActionResult> AddClient(Client client)
        {
            var requiredField = cds.RequiredFieldClient(client);
            if (!requiredField)
            {
                dc.Clients.Add(client);
                await dc.SaveChangesAsync();
                return new ObjectResult(client);
            }
            return null;
        }
        public async Task<ActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return null;
            }
            dc.Entry(client).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = cds.FindClient(id);
            if (client == null)
            {
                return null;
            }
            dc.Clients.Remove(client);
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);

        }
    }
}