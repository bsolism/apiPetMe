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
    public class ProfileHouseApplication : IProfileHouseApplication
    {
        private readonly DataContext dc;
        private readonly IDomainUnitOfWork uow;
        private readonly IMapper mapper;

        public ProfileHouseApplication(DataContext dc, IDomainUnitOfWork uow, IMapper mapper)
        {
            this.dc = dc;
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProfileHouse>> GetHouse()
        {
            return await dc.ProfileHouses.Include(x => x.User).Include(x => x.Pets).ThenInclude(y => y.PetPhotos).ToListAsync();
        }

        public async Task<IEnumerable<ProfileHouse>> GetHouseByUserId(int id)
        {
            return await dc.ProfileHouses.Include(x => x.User).Include(x => x.Pets).ThenInclude(y => y.PetPhotos).Where(x=> x.UserId==id).ToListAsync();
        }

        public async Task<ProfileHouse> FindProfileHouse(int id)
        {
            var House = await dc.ProfileHouses.Include(x=> x.User).Include(x=> x.Pets).ThenInclude(y=> y.PetPhotos).FirstOrDefaultAsync(x => x.ProfileHouseId == id);
            if (House != null)
            {
                return House;
            }
            return null;
        }
        public async Task<ProfileHouse>FindRefugeByEmail(string email)
        {
            var house = await dc.ProfileHouses.Include(x => x.User).Include(x => x.Pets).ThenInclude(y => y.PetPhotos).FirstOrDefaultAsync(x => x.Email == email);
            if (house != null)
            {
                return house;
            }
            return null;
        }
        public async Task<ObjectResult> AddHouse(ProfileHouseDto profileHouseDto)
        {
            var isComplete =  uow.ProfileHouseDomain.isComplete(profileHouseDto);
            if (isComplete != "Complete") return new ObjectResult(isComplete) {StatusCode=500 };
            var findProfileHouse = await FindProfileHouse(profileHouseDto.ProfileId);
            if (findProfileHouse != null) return new ObjectResult("Perfil ya existe") {StatusCode= 500 };
            var findRefugeByEmail = await FindRefugeByEmail(profileHouseDto.Email);
            if (findRefugeByEmail != null) return new ObjectResult("El Email ya está registrado") { StatusCode = 500 };
            uow.ProfileHouseDomain.UploadImage(profileHouseDto);
            var profileHouseMap = mapper.Map<ProfileHouse>(profileHouseDto);
            dc.ProfileHouses.Add(profileHouseMap);
            await dc.SaveChangesAsync();
            return new ObjectResult(profileHouseMap) {StatusCode= 200 };
        }
        public async Task<ObjectResult> Update(int id, ProfileHouseDto profileHouseDto)
        {
            var profile = await dc.ProfileHouses.AsNoTracking().FirstOrDefaultAsync(x => x.ProfileHouseId == profileHouseDto.ProfileId);
            if (id != profileHouseDto.ProfileId) return new ObjectResult("Id not Match") { StatusCode = 500 };
            uow.ProfileHouseDomain.UploadImage(profileHouseDto);
            profile = uow.ProfileHouseDomain.ProfileHouse(profileHouseDto, profile);

            dc.Entry(profile).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            if (res == 0) return new ObjectResult("Save failed") { StatusCode = 500 };
            profile = await dc.ProfileHouses.AsNoTracking().Include(x=> x.User).FirstOrDefaultAsync(x => x.ProfileHouseId == profileHouseDto.ProfileId);
            return new ObjectResult(profile) { StatusCode = 200 };
        }

        public async Task<ObjectResult> Delete(int id)
        {
            var data = await dc.ProfileHouses.AsNoTracking().FirstOrDefaultAsync(x => x.ProfileHouseId == id);
            if (data == null) return new ObjectResult("item no found") { StatusCode = 500 };
            dc.ProfileHouses.Remove(data);
            await dc.SaveChangesAsync();
            return new ObjectResult("Item deleted") { StatusCode = 200 };
        }
    }
}
