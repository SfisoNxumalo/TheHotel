using System.Security.Claims;
using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotel.Domain.Interfaces.Integrations
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDetailsDTO userLoginDetails);
        string GenerateRefreshToken(Guid userId);
        ClaimsPrincipal? ValidateRefreshToken(string refreshToken);
    }
}
