using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;

namespace TheHotel.Application.Services
{
    public class RoomServiceOrderService : IRoomServiceOrderService
    {
        private readonly IRoomServiceOrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly IRoomServiceMenuService _roomServiceMenu;
        private readonly IRealTimeNotifier _realtimeNotifier;

        public RoomServiceOrderService(IRoomServiceOrderRepository orderRepository, IUserService userService, IRoomServiceMenuService roomServiceMenu, IRealTimeNotifier realtimeNotifier)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _roomServiceMenu = roomServiceMenu;
            _realtimeNotifier = realtimeNotifier;
        }

        public async Task<OrderRoomServiceDTO> GetOrderById(Guid orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderRoomServiceDTO>> GetOrdersByUserIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(orderId);
        }

        public async Task<Guid> PlaceOrderAsync(OrderRoomServiceDTO order)
        {
            try
            {
                var userDetails = await _userService.GetUserByIdAsync(order.UserId);

                if (userDetails == null)
                {
                    throw new Exception();
                }

                var cartItemsId = order.items.Select(item => item.Id).ToList();

                var availableMenuItems = await _roomServiceMenu.GetMenuItemsByIdsAsync(cartItemsId);

                var productsById = availableMenuItems.ToDictionary(p => p.Id);

                var errors = new List<string>();
                foreach (var item in order.items)
                {
                    if (!productsById.TryGetValue(item.Id, out var p))
                    {
                        errors.Add($"Product {item.ItemName} not found.");
                        continue;
                    }
                    if (!p.Available) errors.Add($"{p.ItemName} is unavailable.");
                    if (p.Price != item.Price) errors.Add($"{p.ItemName} price changed from {item.Price} to {p.Price}.");
                }

                var orderId = Guid.NewGuid();

                var lstItems = new List<RoomServiceOrderItemEntity>();

                foreach(var item in order.items) {
                    lstItems.Add(new RoomServiceOrderItemEntity { 
                        OrderId = orderId,
                        ItemId = item.Id,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Note = item.note
                    });
                }

                var roomServiceOrder = new RoomServiceOrderEntity
                {
                    Id = orderId,
                    UserId = userDetails.Id,
                    Items = lstItems,
                    Note = order.Note
                };

                await _orderRepository.AddAsync(roomServiceOrder);
                return orderId;
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

            var orderUpdate = new UpdateOrderStatus
            {
                orderId = orderId,
                status = status
            };

            await _realtimeNotifier.BroadcastOrderStatusUpdate(order.UserId, orderUpdate);
        }
    }
}
