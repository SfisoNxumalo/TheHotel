using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderEntity : BaseEntity
    {
        [Required]
        public required Guid UserId { get; set; }

        public string? Note { get; set; } = "";

        [Required]
        public string Status { get; set; } = "Pending";

        public UserEntity? User { get; set; } = null!;

        public required ICollection<RoomServiceOrderItemEntity> Items { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
