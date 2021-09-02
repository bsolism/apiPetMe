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
            return await dc.ProfileHouses.Include(x => x.User).ToListAsync();
        }
        public async Task<ProfileHouse> FindProfileHouse(string email)
        {
            var House = await dc.ProfileHouses.FirstOrDefaultAsync(x => x.Email == email);
            if (House != null)
            {
                return House;
            }
            return null;
        }
        public async Task<ObjectResult> AddHouse(ProfileHouseDto profileHouseDto)
        {
            var isComplete =  uow.ProfileHouseDomain.isComplete(profileHouseDto);
            if (isComplete != "Complete") return new ObjectResult(isComplete) {StatusCode=500 };
            var findProfileHouse = await FindProfileHouse(profileHouseDto.Email);
            if (findProfileHouse != null) return new ObjectResult("Perfil ya existe") {StatusCode= 500 };
            uow.ProfileHouseDomain.UploadImage(profileHouseDto);
            var profileHouseMap = mapper.Map<ProfileHouse>(profileHouseDto);
            dc.ProfileHouses.Add(profileHouseMap);
            await dc.SaveChangesAsync();
            return new ObjectResult(profileHouseMap) {StatusCode= 200 };
        }
    }
}
