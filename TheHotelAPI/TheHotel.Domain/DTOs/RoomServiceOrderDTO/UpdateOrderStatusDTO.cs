using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs.RoomServiceOrderDTO
{
    public class UpdateOrderStatusDTO
    {
        [Required]
        public required Guid orderId {  get; set; }
        [Required]
        public required string status { get; set; }
    }
}
