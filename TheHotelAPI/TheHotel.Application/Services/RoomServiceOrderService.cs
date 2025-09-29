using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class RoomServiceOrderService : IRoomServiceOrderService
    {
        private readonly IRoomServiceOrderRepository _orderRepository;

        public RoomServiceOrderService(IRoomServiceOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersForBookingAsync(Guid bookingId)
        {
            return await _orderRepository.GetOrdersByBookingIdAsync(bookingId);
        }

        public async Task<RoomServiceOrderEntity> PlaceOrderAsync(RoomServiceOrderEntity order)
        {
            await _orderRepository.AddAsync(order);
            return order;

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
