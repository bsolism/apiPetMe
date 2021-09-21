
using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Interface.Application;
using AutoMapper;

namespace apiPetMe.ApplicationServices.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork duow;
        private readonly IMapper mapper;

        public UnitOfWork(DataContext dc, IDomainUnitOfWork duow, IMapper mapper)
        {
            this.dc = dc;
            this.duow = duow;
            this.mapper = mapper;
        }
       public ILoginApplication LoginApplication =>
            new LoginApplication(duow);
       public IUserApplication UserApplication =>
            new UserApplication(dc, duow, mapper);       
       public IRecoveryPassApplication RecoveryPassApplication =>
            new RecoveryPassApplication(dc, duow);
       public IProfileHouseApplication ProfileHouseApplication =>
            new ProfileHouseApplication(dc, duow, mapper);
       public IPetApplication PetApplication =>
             new PetApplication(dc, duow, mapper);
       public IRequestAdoptionApplication RequestAdoptionApplication =>
            new RequestAdoptionApplication(dc, duow);
    }
}
