using apiPetMe.Context;
using apiPetMe.DomainServices.UnitOfWorkDomain;
using apiPetMe.Dto;
using apiPetMe.Interface.Application;
using apiPetMe.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPetMe.ApplicationServices
{
    public class PetApplication : IPetApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork uow;
        private readonly IMapper mapper;

        public PetApplication(DataContext dc, IDomainUnitOfWork uow, IMapper mapper)
        {
            this.dc = dc;
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Pet>> Get()
        {
            return await dc.Pets.Include(x => x.ProfileHouse).Include(x => x.PetPhotos).ToListAsync();
        }
     
        public async Task<Pet> FindById(int id)
        {
            var pet = await dc.Pets.Include(x => x.ProfileHouse).Include(x => x.PetPhotos).FirstOrDefaultAsync(x => x.PetId == id);
            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        public async Task<IEnumerable<Pet>> FindByHouseId(int id)
        {
            var pet = await dc.Pets.Include(x => x.PetPhotos).Where(x=> x.ProfileHouseId== id).ToListAsync();
            if (pet != null)
            {
                return pet;
            }
            return null;
        }

        public async Task<ObjectResult> Add(PetDto petDto)
        {
            var Complete = uow.PetDomain.Complete(petDto);
            if (Complete != "Complete") return  new ObjectResult(Complete) { StatusCode=500};
            var PetMap = mapper.Map<Pet>(petDto);
            dc.Pets.Add(PetMap);
            await dc.SaveChangesAsync();
           
                foreach(var petPhoto in petDto.File)
                {
                    var image=uow.PetDomain.UploadImage(petPhoto);
                    var petPhotoNew = new PetPhotos { Image = image, PetId = PetMap.PetId };
                    dc.PetPhotos.Add(petPhotoNew);
                    await dc.SaveChangesAsync();

                }
                     
            
            return new ObjectResult(PetMap);
        }
    }
}
