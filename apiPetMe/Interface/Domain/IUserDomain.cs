using apiPetMe.Dto;
using apiPetMe.Models;

namespace apiPetMe.Interface.Domain
{
    public interface IUserDomain
    {
        bool isComplete(User user);
        UserDto UploadImage(UserDto userDto);
    }
}
