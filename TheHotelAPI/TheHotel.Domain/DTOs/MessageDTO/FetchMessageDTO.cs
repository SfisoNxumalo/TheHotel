namespace TheHotel.Domain.DTOs.MessageDTO
{
    public class FetchMessageDTO
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid SenderId { get; set; }

        public required string MessageText { get; set; }

        public required Guid StaffId { get; set; }

        public required DateTime CreatedDate { get; set; }

    }
}
