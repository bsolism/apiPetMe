using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class DonationApplication : IDonationApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork uow;

        public DonationApplication(DataContext dc, IDomainUnitOfWork uow)
        {
            this.dc = dc;
            this.uow = uow;
        }
        public async Task<ObjectResult> Add(Donation donation)
        {
            var Complete = uow.DonationDomain.Complete(donation);
            if (Complete != "Complete") return new ObjectResult(Complete) { StatusCode = 500 };
            dc.Donations.Add(donation);
            await dc.SaveChangesAsync();
            return new ObjectResult(donation);
        }
    }
}
