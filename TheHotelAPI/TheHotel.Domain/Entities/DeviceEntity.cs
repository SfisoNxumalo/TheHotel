using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class DeviceEntity : BaseEntity
    {

        [Required]
        public string DeviceUUID { get; set; } = null!;

        public Guid? RoomId { get; set; }

        public RoomEntity? Room { get; set; } = null!;
    }
}
