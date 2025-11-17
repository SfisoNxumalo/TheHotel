using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        public required Guid? DeviceId { get; set; }

        [Required]
        public Guid RoomId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } = "Active";

        public UserEntity User { get; set; } = null!;
        public RoomEntity Room { get; set; } = null!;
        public DeviceEntity? Device { get; set; } = null!;
        public ICollection<RoomServiceOrderEntity> Orders { get; set; } = new List<RoomServiceOrderEntity>();
    }
}
