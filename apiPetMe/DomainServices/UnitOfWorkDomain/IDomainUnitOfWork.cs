using apiPetMe.Interface.Domain;

namespace apiPetMe.DomainServices.UnitOfWorkDomain
{
    public interface IDomainUnitOfWork
    {
        ILoginDomainService LoginDomainService { get; }
        ICreateToken CreateToken { get; }
        IUserDomain UserDomain { get; }
        IRecoveryPassDomain RecoveryPassDomain { get; }
        IEmailSender EmailSender { get; }
        IProfileHouseDomain ProfileHouseDomain { get; }
        IPetDomain PetDomain { get; }
        IRequestAdoptionDomain RequestAdoptionDomain { get; }
    }
}
