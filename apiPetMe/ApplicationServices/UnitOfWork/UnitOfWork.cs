
using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Interface.Application;

namespace apiPetMe.ApplicationServices.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork duow;
        private readonly LoginResDto loginResDTO;

        public UnitOfWork(DataContext dc, IDomainUnitOfWork duow, LoginResDto loginResDTO)
        {
            this.dc = dc;
            this.duow = duow;
            this.loginResDTO = loginResDTO;
        }
       public ILoginApplication LoginApplication =>
       new LoginApplication(loginResDTO, duow);
       public IUserApplication UserApplication =>
       new UserApplication(dc, duow);
    }
}
