using apiPetMe.Dto;
using apiPetMe.Models;

namespace apiPetMe.Interface.Domain
{
    public interface IUserDomain
    {
        string isComplete(User user);
        UserDto UploadImage(UserDto userDto);
        User User(UserDto userDto, User user);
    }
}
