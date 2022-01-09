using apiPetMe.DomainServices;
using apiPetMe.Dto;
using apiPetMe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiPetMet
{
    [TestClass]
    public class TestPet
    {
        [TestMethod]
        public void ValidarDatosMascotas()
        {
            //Arrange
            List<IFormFile> files = new List<IFormFile>();
            files.Add(new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.jpg"));
            files.Add(new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy2.jpg"));
        
            var pet = new PetDto
            {
                Name = "Black",
                Category = "Pequeño",
                Description = "Not Null",
                Old = 23,
                Weight = "23 kg",
                Height = "23 cm",
                Sex = "Male",
                Color = "Black",
                ProfileHouseId = 1,
                File=files,

            };

            //Act
            var petDomain = new PetDomain();
            var result = petDomain.Complete(pet);

            //Assert
            Assert.AreEqual("Complete", result);

        }

    }
}
