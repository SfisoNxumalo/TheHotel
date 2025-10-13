using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderEntity : BaseEntity
    {
        [Required]
        public required Guid BookingId { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        public BookingEntity? Booking { get; set; } = null!;

        public required ICollection<RoomServiceOrderItemEntity> Items { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
