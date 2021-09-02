using apiPetMe.Interface.Application;

namespace apiPetMe.ApplicationServices.UnitOfWork
{
    public interface IUnitOfWork
    {
        ILoginApplication LoginApplication { get; }
        IUserApplication UserApplication { get; }
        IRecoveryPassApplication RecoveryPassApplication { get; }
        IProfileHouseApplication ProfileHouseApplication { get; }
        IPetApplication PetApplication { get; }
    }
}
