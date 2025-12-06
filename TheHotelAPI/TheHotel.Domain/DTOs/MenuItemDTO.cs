namespace TheHotel.Domain.DTOs
{
    public class MenuItemDTO
    {
        public required Guid Id { get; set; }
        public required string ItemName { get; set; } = null!;
        public required string image { get; set; }

        public required string? Description { get; set; }

        public required decimal Price { get; set; }

        public required bool Available { get; set; } = true;
    }
}
