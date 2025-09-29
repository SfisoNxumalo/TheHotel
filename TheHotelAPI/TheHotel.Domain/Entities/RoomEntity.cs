using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        [Required]
        public string RoomNumber { get; set; } = null!;

        [Required]
        public string? RoomType { get; set; }

        [Required]
        public string Status { get; set; } = "Available";

        public DeviceEntity? Device { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}
