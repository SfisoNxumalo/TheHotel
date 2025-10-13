using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderEntity : BaseEntity
    {
        [Required]
        public Guid BookingId { get; set; }


        public Guid? DeviceId { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        public BookingEntity Booking { get; set; } = null!;
        public DeviceEntity Device { get; set; } = null!;
        public ICollection<RoomServiceOrderItemEntity> Items { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
