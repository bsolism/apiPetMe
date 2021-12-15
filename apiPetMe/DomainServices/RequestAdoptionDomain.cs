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
        public RequestAdoption RequestAdoption(RequestAdoption requestAdoption, RequestAdoption newRequest)
        {
            if (requestAdoption.Name != null) newRequest.Name = requestAdoption.Name;
            if (requestAdoption.Email != null) newRequest.Email = requestAdoption.Email;
            if (requestAdoption.City != null) newRequest.City = requestAdoption.City;
            if (requestAdoption.Comentary != null) newRequest.Comentary = requestAdoption.Comentary;
            if (requestAdoption.Address != null) newRequest.Address = requestAdoption.Address;
            if (requestAdoption.Phone != null) newRequest.Phone = requestAdoption.Phone;
            if (requestAdoption.UserId != 0) newRequest.UserId = requestAdoption.UserId;
            if (requestAdoption.PetId != 0) newRequest.PetId = requestAdoption.PetId;
            if (requestAdoption.ProfileHouseId != 0) newRequest.ProfileHouseId = requestAdoption.ProfileHouseId;
            if (requestAdoption.TimeAlone != 0) newRequest.TimeAlone = requestAdoption.TimeAlone;
            if (requestAdoption.Country != null) newRequest.Country = requestAdoption.Country;
            if (requestAdoption.Dni != null) newRequest.Dni = requestAdoption.Dni;
            if (requestAdoption.Province != null) newRequest.Province = requestAdoption.Province;
            if (requestAdoption.WhatPet != null) newRequest.WhatPet = requestAdoption.WhatPet;
            if (requestAdoption.Why != null) newRequest.Why = requestAdoption.Why;
            if (requestAdoption.HasPets != newRequest.HasPets) newRequest.HasPets = requestAdoption.HasPets;
            if (requestAdoption.isApproved != newRequest.isApproved) newRequest.isApproved = requestAdoption.isApproved;
            if (requestAdoption.isActive != newRequest.isActive) newRequest.isActive = requestAdoption.isActive;
            if (requestAdoption.isRejected != newRequest.isRejected) newRequest.isRejected = requestAdoption.isRejected;
            if (requestAdoption.isActive != newRequest.isActive) newRequest.isActive = requestAdoption.isActive;

            return newRequest;
        }

    }
}
