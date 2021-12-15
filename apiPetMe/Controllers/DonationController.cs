using apiPetMe.ApplicationServices.UnitOfWork;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace apiPetMe.Controllers
{
    public class DonationController : BaseController
    {
        private readonly IUnitOfWork uow;

        public DonationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]Donation donation)
        {
            var data = await uow.DonationApplication.Add(donation);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
    }
}
