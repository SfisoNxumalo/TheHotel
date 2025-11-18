using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotel.Domain.Interfaces.Integrations
{
    public interface ITokenService
    {
        Task<string> EncodeToken(UserDetailsDTO userLoginDetails);
    }
}
