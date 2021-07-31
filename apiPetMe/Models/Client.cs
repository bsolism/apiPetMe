using System;
using System.ComponentModel.DataAnnotations;

namespace apiPetMe.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CivilState { get; set; }
        public bool IsActive { get; set; }







    }
}