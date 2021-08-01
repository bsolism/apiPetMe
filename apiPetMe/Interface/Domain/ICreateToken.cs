using apiPetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Interface.Domain
{
    public interface ICreateToken
    {
        string CreateJWT(User user);

    }
}
