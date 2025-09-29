using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}
