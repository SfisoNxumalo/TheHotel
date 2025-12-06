using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderEntity : BaseEntity
    {
        [Required]
        public required Guid UserId { get; set; }

        [StringLength(500)]
        public string? Note { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; } = null!;

        public required ICollection<RoomServiceOrderItemEntity> Items { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
