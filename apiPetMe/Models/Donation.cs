using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiPetMe.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        public string Prefix { get; set; }
        public decimal Monto { get; set; }
        public int ProfileHouseId { get; set; }
        public bool Suscription { get; set; }
        public ProfileHouse ProfileHouse { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
    }
}
