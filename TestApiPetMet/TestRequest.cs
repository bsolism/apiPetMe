using apiPetMe.DomainServices;
using apiPetMe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiPetMet
{
    [TestClass]
    public class TestRequest
    {
        [TestMethod]
        public void ValidarSolicitudDeAdopcion()
        {
            //Arrange
            var request = new RequestAdoption
            {
                Name="Juan",
                City="SPS",
                Address="Bo. Bonito",
                Phone="92929292",
                Email="info@info.com",
                Country="Hn",
                Dni="010101001",
                PetId=1,
                ProfileHouseId=1,
                Province="Cortes",
                TimeAlone=2,
                Why="Me gustan"
            };

            //Act
            var requestDomain = new RequestAdoptionDomain();
            var result = requestDomain.isComplete(request);

            //Assert
            Assert.AreEqual("Complete", result);
        }
    }
}
