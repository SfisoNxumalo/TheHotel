namespace TheHotel.Domain.DTOs.RoomServiceItem
{
    public class OrderItemDTO
    {
        public required Guid Id { get; set; }
        public required string ItemName { get; set; } = null!;

        public required decimal Price { get; set; }

        public required int Quantity { get; set; }

        public required string note { get; set; }


    }
}
