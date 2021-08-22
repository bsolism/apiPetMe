using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.Dto
{
    public class RecoveryPassDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPass { get; set; }
    }
}
