using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs.UserDTO
{
    public class UserDetailsDTO
    {

        public Guid Id { get; set; }

        public required string FullName { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        public string Token { get; set; }
        public string Role { get; set; }
    }
}
