
using apiPetMe.DomainServices;
using apiPetMe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestApiPetMet
{
    [TestClass]
    public class TestUser
    {     
        [TestMethod]
        public void ValidarCamposUsuario()
        {
            //Arrange
            var user = new User
            {
                Name = "Pedro",
                Email = "j@j.com",
                PhoneNumber = "9494994",
                Password = "olaMund0",
            };
            //Act
            var userDomain = new UserDomain();
            var resultado =userDomain.isComplete(user);

            //Assert

            Assert.AreEqual("Complete", resultado);

        }
       
    }
}
