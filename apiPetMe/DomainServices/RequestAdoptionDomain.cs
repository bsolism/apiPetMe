using apiPetMe.Context;
using apiPetMe.Interface.Domain;
using apiPetMe.Models;

namespace apiPetMe.DomainServices
{
    public class RequestAdoptionDomain : IRequestAdoptionDomain
    {
        private readonly DataContext dc;

        public RequestAdoptionDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public string isComplete(RequestAdoption requestAdoption)
        {
            if (requestAdoption.Name == null) return "Name not found";
            if (requestAdoption.City == null) return "City not found";
            if (requestAdoption.Address == null) return "Address not found";
            if (requestAdoption.Phone == null) return "Phone not found";
            if (requestAdoption.Email == null) return "Email not found";
            if (requestAdoption.Country == null) return "Country not found";
            if (requestAdoption.Dni == null) return "DNI not found";
            if (requestAdoption.PetId == 0) return "ID Pet not found";
            if (requestAdoption.ProfileHouseId == 0) return "ID Refuge House not found";
            if (requestAdoption.Province == null) return "Province not found";
            if (requestAdoption.TimeAlone == 0) return "Time Alone not found";
            if (requestAdoption.Why == null) return "Why not found";
            return "Complete";
        }

    }
}
