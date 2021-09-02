using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Models
{
    public class PetPhotos
    {
        [Key]
        public int PetPhotoId { get; set; }
        public string Image { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
