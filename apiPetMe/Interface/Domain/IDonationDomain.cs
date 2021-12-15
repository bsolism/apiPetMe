using apiPetMe.Models;

namespace apiPetMe.Interface.Domain
{
    public interface IDonationDomain
    {
        string Complete(Donation donation);
    }
}
