using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiPetMe.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Old { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }
        public string ClinicHistory { get; set; }
        public string LifeHistory { get; set; }
        public bool isAdoptable { get; set; }
        public int ProfileHouseId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        public ProfileHouse ProfileHouse { get; set; }
        public List<PetPhotos> PetPhotos { get; set; }
        public List<RequestAdoption> RequestAdoptions { get; set; }


    }
}
