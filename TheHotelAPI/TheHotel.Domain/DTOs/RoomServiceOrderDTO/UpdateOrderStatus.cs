namespace TheHotel.Domain.DTOs.RoomServiceOrderDTO
{
    public class UpdateOrderStatus
    {
        public Guid orderId {  get; set; }
        public string status { get; set; }
    }
}
