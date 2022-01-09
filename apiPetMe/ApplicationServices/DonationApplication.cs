using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var res = await dc.Donations.AsNoTracking().Include(x => x.Pet).Include(x => x.ProfileHouse).FirstOrDefaultAsync(x => x.DonationId == donation.DonationId);
            return new ObjectResult(res);
        }
    }
}
