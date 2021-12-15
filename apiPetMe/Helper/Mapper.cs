using apiPetMe.Dto;
using apiPetMe.Models;
using AutoMapper;

namespace apiPetMe.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProfileHouseDto, ProfileHouse>();
            CreateMap<PetPhotosDto, PetPhotos>();
            CreateMap<PetDto, Pet>();
        }
    }
}
