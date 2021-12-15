using Microsoft.AspNetCore.Http;

namespace apiPetMe.Dto
{
    public class ProfileHouseDto
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Rtn { get; set; }
        public string AccountBank { get; set; }
        public string TypeAccount { get; set; }
        public string BankName { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
