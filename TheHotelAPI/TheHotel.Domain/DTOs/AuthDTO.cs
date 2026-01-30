using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs
{
    public class AuthDTO
    {
        [Required]
        public required string email { get; set; }

        [Required]
        public required string password { get; set; }
    }
}
