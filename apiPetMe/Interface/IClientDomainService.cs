using apiPetMe.Models;

namespace apiPetMe.Interface
{
    public interface IClientDomainService
    {
        bool RequiredFieldClient(Client client);
        Client FindClient(int id);
    }
}