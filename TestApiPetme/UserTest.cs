using apiPetMe.DomainServices;
using apiPetMe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiPetme
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        
        public void validarUsuario()
        {
            //Arrange
            User user = new User
            {
                Name = "Juan",
                Email = "j@demo.com",
                PhoneNumber = "9494949494",
                Password = "olaMundo"
            };

            //Act
            var userDomain = new UserDomain();
            var resultado = userDomain.isComplete(user);

            //Assert
            Assert.AreEqual("Complete", resultado);


        }
    }
}
