using TheHotel.Domain.DTOs;
using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotel.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserDetailsDTO> Login(AuthDTO user);

        Task<bool> Register(AddUserDTO newUser);
    }
}
