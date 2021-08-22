using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string code);
    }
}
