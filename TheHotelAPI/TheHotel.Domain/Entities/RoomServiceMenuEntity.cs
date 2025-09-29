using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceMenuEntity : BaseEntity
    {
        [Required]
        public string ItemName { get; set; } = null!;

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; } = true;

        public ICollection<RoomServiceOrderItemEntity> OrderItems { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
