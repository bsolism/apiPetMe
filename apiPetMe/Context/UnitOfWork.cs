using apiPetMe.ApplicationServices;
using apiPetMe.DomainServices;
using apiPetMe.Interface;

namespace apiPetMe.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IClientDomainService cds;
        public UnitOfWork(DataContext dc, IClientDomainService cds)
        {
            this.cds = cds;
            this.dc = dc;
        }

        public IClientDomainService ClientDomainService =>
        new ClientDomainService(dc);
        public IClientApplication ClientApplication =>
        new ClientApplication(dc, cds);
    }
}