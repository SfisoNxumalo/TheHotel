using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class RoomServiceOrderItemEntity : BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public decimal Price { get; set; }

        public RoomServiceOrderEntity? Order { get; set; } = null!;
        public RoomServiceMenuEntity? Item { get; set; } = null!;
    }
}
