using apiPetMe.Context;
using apiPetMe.Interface.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
        private readonly IWebHostEnvironment environment;

        public DomainUnitOfWork(DataContext dc, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.configuration = configuration;
            this.environment = environment;
        }
        public ILoginDomainService LoginDomainService =>
        new LoginDomainService(dc);
        public ICreateToken CreateToken =>
        new CreateToken(configuration);
        public IUserDomain UserDomain =>
        new UserDomain(dc);

    }
}
