using System.ComponentModel.DataAnnotations;

namespace apiPetMe.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public int Rol { get; set; }
        public string Password { get; set; }
        public string Sal { get; set; }
    }
}
