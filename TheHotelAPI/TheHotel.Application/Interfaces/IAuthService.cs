using TheHotel.Application.Models;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotel.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Login(AuthDTO user);

        Task<bool> Register(AddUserDTO newUser);
    }
}
