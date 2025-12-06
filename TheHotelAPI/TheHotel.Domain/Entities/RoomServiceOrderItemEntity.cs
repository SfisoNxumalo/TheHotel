using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderItemEntity : BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Note { get; set; } = "";

        [ForeignKey(nameof(OrderId))]
        public RoomServiceOrderEntity? Order { get; set; } = null!;

        [ForeignKey(nameof(ItemId))]
        public RoomServiceMenuEntity? Item { get; set; } = null!;
    }
}
