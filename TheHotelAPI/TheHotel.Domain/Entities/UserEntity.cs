using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public required string FullName { get; set; } = null!;

        [Required]
        public required string Email { get; set; } = null!;

        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}
