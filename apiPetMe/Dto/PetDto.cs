using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Dto
{
    public class PetDto
    {
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
        public DateTime DataCreated { get; set; }
        public List<IFormFile> File { get; set; }
        
    }
}
