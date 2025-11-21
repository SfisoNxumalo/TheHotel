using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotel.Application.Models
{
    public class AuthModel
    {
        public UserDetailsDTO userDetails { get; set; }
        public string RefreshToken { get; set; } 
    }
}
