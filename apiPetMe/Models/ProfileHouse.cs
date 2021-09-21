using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiPetMe.Models
{
    public class ProfileHouse
    {
        [Key]
        public int ProfileHouseId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
        public List<RequestAdoption> RequestAdoptions { get; set; }
    }
}
