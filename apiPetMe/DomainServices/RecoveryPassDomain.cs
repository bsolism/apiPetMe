using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace apiPetMe.DomainServices
{
    public class RecoveryPassDomain : IRecoveryPassDomain
    {
        

        public RecoveryPassDomain()
        {
            
        }

        public string validatorRecovery(RecoveryPassDto dataRecovery, HttpContext session)
        {
            
            if (dataRecovery.NewPass == null || dataRecovery.NewPass == "") return "Contraseña no valida";
           
            var client = session.User.Claims.First(c => c.Type == "code");
            if (dataRecovery.Code != client.Value) return "Codigo no coincide";
            var email = session.User.Claims.First(c => c.Type.Contains("email"));
            if (email.Value != dataRecovery.Email) return "Email no valido";
            var expDate = session.User.Claims.First(c => c.Type == "exp");
            int currentDate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            if (currentDate > Convert.ToInt32(expDate.Value)) return "Sesion Expiró";

            return "true";
        }

        public void SendEmail(string email)
        {

        }
    }
}
