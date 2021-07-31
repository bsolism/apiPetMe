
namespace apiPetMe.Interface
{
    public interface IUnitOfWork
    {
        IClientDomainService ClientDomainService { get; }
        IClientApplication ClientApplication { get; }
    }
}