using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Context;
using apiPetMe.Dto;
using apiPetMe.Interface.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.DomainServices.UnitOfWorkDomain
{
    public class DomainUnitOfWork : IDomainUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IConfiguration configuration;
        private readonly IOptions<EmailSenderOptions> options;
        private readonly IWebHostEnvironment environment;

        public DomainUnitOfWork(DataContext dc, IConfiguration configuration, IOptions<EmailSenderOptions> options, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.configuration = configuration;
            this.options = options;
            this.environment = environment;
        }
        public ILoginDomainService LoginDomainService =>
        new LoginDomainService(dc);
        public ICreateToken CreateToken =>
        new CreateToken(configuration);
        public IUserDomain UserDomain =>
        new UserDomain(dc, environment);
        public IRecoveryPassDomain RecoveryPassDomain =>
        new RecoveryPassDomain();
        public IEmailSender EmailSender =>
        new EmailSender(options);
        public IProfileHouseDomain ProfileHouseDomain =>
            new ProfileHouseDomain(dc, environment);
        public IPetDomain PetDomain =>
            new PetDomain(dc, environment);

    }
}
