namespace TheHotel.Domain.DTOs
{
    public class MenuItemDTO
    {
        public required Guid Id { get; set; }
        public  string ItemName { get; set; } = null!;
        public string image { get; set; }

        public string? Description { get; set; }

        public required decimal Price { get; set; }

        public required bool Available { get; set; } = true;
    }
}
