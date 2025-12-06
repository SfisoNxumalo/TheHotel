using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [StringLength(150)]
        public required string FullName { get; set; } = null!;

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public required string Email { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = "User";

        [Required]
        [StringLength(20)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        [StringLength(500)]
        public required string PasswordHash { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}
