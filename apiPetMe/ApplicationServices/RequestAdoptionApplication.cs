using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class RequestAdoptionApplication : IRequestAdoptionApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork uow;

        public RequestAdoptionApplication(DataContext dc, IDomainUnitOfWork uow)
        {
            this.dc = dc;
            this.uow = uow;
        }
        public async Task<IEnumerable<RequestAdoption>> Get()
        {
            return await dc.RequestAdoptions.Include(x => x.Pet).ToListAsync();
        }
        public async Task<IEnumerable<RequestAdoption>> FindByHouse(int id)
        {
            return await dc.RequestAdoptions.Include(x => x.Pet).Where(x => x.ProfileHouseId == id).ToListAsync();
            
        }
        public async Task<RequestAdoption> FindById(int id)
        {
            var data = await dc.RequestAdoptions.Include(x=> x.Pet).FirstOrDefaultAsync(x=> x.RequestAdoptionId== id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<IEnumerable<RequestAdoption>> FindByUserId(int id)
        {
            var data = await dc.RequestAdoptions.Include(x => x.Pet).ThenInclude(x=> x.PetPhotos).Where(x => x.UserId == id).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(RequestAdoption requestAdoption)
        {
            var isComplete = uow.RequestAdoptionDomain.isComplete(requestAdoption);
            if (isComplete != "Complete") return new ObjectResult(isComplete) { StatusCode = 500 };
            dc.RequestAdoptions.Add(requestAdoption);
            await dc.SaveChangesAsync();
            return new ObjectResult(requestAdoption) { StatusCode = 200 };
        }
        public async Task<ObjectResult> Update(int id, RequestAdoption requestAdoption)
        {
            var data = await dc.RequestAdoptions.AsNoTracking().FirstOrDefaultAsync(x => x.RequestAdoptionId == requestAdoption.RequestAdoptionId);
            if (id != requestAdoption.RequestAdoptionId) return new ObjectResult("Id not Match") { StatusCode = 500 };

            data = uow.RequestAdoptionDomain.RequestAdoption(requestAdoption, data);
            dc.Entry(data).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            if (res == 0) return new ObjectResult("Save failed") { StatusCode = 500 };
            data = await dc.RequestAdoptions.AsNoTracking().Include(x => x.Pet).FirstOrDefaultAsync(x => x.RequestAdoptionId == id);
            return new ObjectResult(data) { StatusCode = 200 };
        }


    }
}
