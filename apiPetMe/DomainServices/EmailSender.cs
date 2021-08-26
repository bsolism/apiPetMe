using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace apiPetMe.DomainServices
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient Cliente { get; }
        private EmailSenderOptions Options { get; }

        public EmailSender(IOptions<EmailSenderOptions> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }
        public Task SendEmailAsync(string email,  string code)
        {
            var correo = new MailMessage(
                from: Options.Email, 
                to: email,
                subject: "Codigo de recuperacion de cuenta", 
                body: "Ingresa el siguiente codigo para reestablecer tu contraseña"+ Environment.NewLine +
                code + Environment.NewLine +
                "Este codigo es válido por 2 horas" + Environment.NewLine +
                "Enviamos este email para ayudarte a iniciar sesión en tu cuenta de PetMe" + Environment.NewLine +
                "" + Environment.NewLine +
                "Si no intentaste iniciar sesión en tu cuenta o si tú no solicitaste este email," +
                " no te preocupes, es posible que alguien haya ingresado tu dirección de email por error. " +
                "Puedes ignorar o eliminar este email y seguir usando tu contraseña de siempre para iniciar sesión"
                );
            correo.IsBodyHtml = true;
            return Cliente.SendMailAsync(correo);
        }
    }
}
