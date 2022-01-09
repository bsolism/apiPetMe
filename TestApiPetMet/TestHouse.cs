using apiPetMe.DomainServices;
using apiPetMe.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiPetMet
{
    [TestClass]
    public class TestHouse
    {
        [TestMethod]
        public void ValidarRefugio()
        {
            //Arrange
            var house = new ProfileHouseDto
            {
                Name = "PetHouse",
                City = "SPS",
                Address = "Bo. Bonito",
                Phone="2555353",
                Email="info@info.com",
                UserId=1
            };

            //Act
            var houseDomain = new ProfileHouseDomain();
            var result = houseDomain.isComplete(house);

            //Assert
            Assert.AreEqual("Complete", result);
        }
    }
}
