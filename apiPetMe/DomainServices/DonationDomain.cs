using apiPetMe.Context;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;

namespace apiPetMe.DomainServices
{
    public class DonationDomain : IDonationDomain
    {
        private readonly DataContext dc;
        public DonationDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public string Complete(Donation donation)
        {
            if (donation.Monto == 0) return "Monto not found";
            if (donation.ProfileHouseId == 0) return "House not found";
            if (donation.PetId == 0) return "Pet not found";

            return "Complete";
        }
    }
}
