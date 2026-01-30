using Microsoft.Extensions.Logging;
using System.Text;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;

namespace TheHotel.Application.Services
{

    // Handles all business logic related to Room Service orders.
    // This service manages order creation, validation, content safety checks,
    // retrieval of orders, and status updates. It coordinates user validation,
    // menu item verification, and real-time notifications, acting as the 
    // application layer between controllers, repositories, and integrations.

    public class RoomServiceOrderService : IRoomServiceOrderService
    {
        private readonly IRoomServiceOrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly IRoomServiceMenuService _roomServiceMenu;
        private readonly IRealTimeNotifier _realtimeNotifier;
        private readonly ILogger<RoomServiceOrderService> _logger;
        private readonly ContentManager _contentManager;

        public RoomServiceOrderService(IRoomServiceOrderRepository orderRepository, IUserService userService, 
            IRoomServiceMenuService roomServiceMenu, IRealTimeNotifier realtimeNotifier, ILogger<RoomServiceOrderService> logger, ContentManager contentManager)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _roomServiceMenu = roomServiceMenu;
            _realtimeNotifier = realtimeNotifier;
            _logger = logger;
            _contentManager = contentManager;
        }

        public async Task<IEnumerable<OrderRoomServiceDTO>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<OrderRoomServiceDTO> GetOrderById(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
                throw new NotFoundException("The Hotel order with the provided Id was not found");
            return order;
        }

        public async Task<IEnumerable<OrderRoomServiceDTO>> GetOrdersByUserIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(orderId);
        }

        /// <summary>
        /// Places a new room service order. This includes validating the user,
        /// checking each menu item for availability and price changes, performing
        /// content safety checks on user notes, constructing the full order entity,
        /// and saving it to the repository.
        /// </summary>

        public async Task<Guid> PlaceOrderAsync(OrderRoomServiceDTO order)
        {
            try
            {
                var userDetails = await _userService.GetUserByIdAsync(order.UserId);

                if (userDetails == null)
                {
                    _logger.LogError($"User ${order.UserId} found");
                    throw new UserNotFoundException($"User ${order.UserId} found");
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
                StringBuilder userNotes = new StringBuilder();
                foreach(var item in order.items) {
                    lstItems.Add(new RoomServiceOrderItemEntity { 
                        OrderId = orderId,
                        ItemId = item.Id,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Note = item.note
                    });

                    if (!string.IsNullOrWhiteSpace(item.note))
                    {
                        userNotes.AppendLine(item.note);
                    }
                }

                if (!string.IsNullOrWhiteSpace(userNotes.ToString().Trim()))
                {
                    var contentResults = await _contentManager.VerifyContentAsync(userNotes.ToString().Trim());
                    
                    if (contentResults.Equals("fail", StringComparison.OrdinalIgnoreCase))
                        throw new InappropriateContentException("Your message includes content that cannot be processed due to safety and policy restrictions.");
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

        /// <summary>
        /// Updates the status of an existing room service order. After persisting
        /// the change, a real-time notification is broadcast to the user to reflect
        /// the updated status.
        /// </summary>

        public async Task UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null) throw new NoOrderFoundException("Order not found");

            order.Status = status;
            await _orderRepository.UpdateAsync(order);

            var orderUpdate = new UpdateOrderStatusDTO
            {
                orderId = orderId,
                status = status
            };

            await _realtimeNotifier.BroadcastOrderStatusUpdate(order.UserId, orderUpdate);
        }
    }
}
