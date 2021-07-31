using apiPetMe.Context;
using apiPetMe.Interface;
using apiPetMe.Models;
using System;

namespace apiPetMe.DomainServices
{
    public class ClientDomainService : IClientDomainService
    {
        private readonly DataContext dc;
        public ClientDomainService(DataContext dc)
        {
            this.dc = dc;

        }
        public bool RequiredFieldClient(Client client)
        {
            if (client.Name == null) return true;
            if (client.BirthDate == new DateTime(0)) return true;
            if (client.CivilState == null) return true;
            return false;
        }
        public Client FindClient(int id)
        {
            var client = dc.Clients.Find(id);
            if (client == null)
            {
                return null;
            }
            return client;
        }
    }
}