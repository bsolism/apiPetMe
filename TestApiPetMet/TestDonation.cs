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
    public class TestDonation
    {
        [TestMethod]
        public void ValidarDonacion()
        {
            //Arrange
            var donation = new Donation
            {
                Monto = 30,
                ProfileHouseId = 1,
                PetId = 1
            };

            //Act
            var donationDomain = new DonationDomain();
            var result = donationDomain.Complete(donation);

            //Assert
            Assert.AreEqual("Complete", result);
        }
    }
}
