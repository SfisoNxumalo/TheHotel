using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceMenuEntity : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string ItemName { get; set; } = null!;

        [StringLength(500)]
        public string? image { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; } = true;

        public ICollection<RoomServiceOrderItemEntity> OrderItems { get; set; } = new List<RoomServiceOrderItemEntity>();
    }
}
