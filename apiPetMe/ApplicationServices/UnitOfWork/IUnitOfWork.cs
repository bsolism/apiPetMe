using apiPetMe.Interface.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices.UnitOfWork
{
    public interface IUnitOfWork
    {
        ILoginApplication LoginApplication { get; }
        IUserApplication UserApplication { get; }
    }
}
