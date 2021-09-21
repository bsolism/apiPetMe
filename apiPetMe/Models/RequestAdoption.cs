

using System.ComponentModel.DataAnnotations;

namespace apiPetMe.Models
{
    public class RequestAdoption
    {
        [Key]
        public int RequestAdoptionId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Comentary { get; set; }
        public string Country { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public bool HasPets { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int PetId { get; set; }
        public bool isApproved { get; set; }
        public bool isActive { get; set; }
        public Pet Pet { get; set; }
        public int ProfileHouseId { get; set; }
        public ProfileHouse ProfileHouse { get; set; }
        public string Province { get; set; }
        public int TimeAlone { get; set; }
        public string WhatPet { get; set; }
        public string Why { get; set; }

    }
}

