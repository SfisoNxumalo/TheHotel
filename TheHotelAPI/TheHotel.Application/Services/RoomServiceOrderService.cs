using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class RoomServiceOrderService : IRoomServiceOrderService
    {
        private readonly IRoomServiceOrderRepository _orderRepository;
        private readonly IBookingService _bookingService;

        public RoomServiceOrderService(IRoomServiceOrderRepository orderRepository, IBookingService bookingService)
        {
            _orderRepository = orderRepository;
            _bookingService = bookingService;
        }

        public async Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersForBookingAsync(Guid bookingId)
        {
            return await _orderRepository.GetOrdersByBookingIdAsync(bookingId);
        }

        public async Task<RoomServiceOrderEntity> PlaceOrderAsync(OrderRoomServiceDTO order)
        {
            try
            {
                var bookingDetails = await _bookingService.GetBookingByIdAsync(order.UserId);

                if (bookingDetails == null)
                {
                    throw new Exception();
                }

                var orderId = Guid.NewGuid();

                var lstItems = new List<RoomServiceOrderItemEntity>();

                foreach(var item in order.items) {
                    lstItems.Add(new RoomServiceOrderItemEntity { 
                        OrderId = orderId,
                        ItemId = item.ItemId,
                        Price = 10,
                        Quantity = item.Quantity,
                    });
                }

                var roomServiceOrder = new RoomServiceOrderEntity
                {
                    Id = orderId,
                    BookingId = bookingDetails.Id,
                    Items = lstItems
                };



                await _orderRepository.AddAsync(roomServiceOrder);
                return roomServiceOrder;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new ArgumentException("Order not found");

            order.Status = status;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
