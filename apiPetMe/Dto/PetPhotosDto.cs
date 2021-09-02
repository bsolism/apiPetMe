using Microsoft.AspNetCore.Http;

namespace apiPetMe.Dto
{
    public class PetPhotosDto
    {
        public string Image { get; set; }
        public int PetId { get; set; }
        public IFormFile File { get; set; }
    }
}
