using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.DTOs.RoomServiceItem;
using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class RoomServiceOrderRepository : GenericRepository<RoomServiceOrderEntity>, IRoomServiceOrderRepository
    {
        private readonly HotelContext _context;

        public RoomServiceOrderRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderRoomServiceDTO> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.RoomServiceOrders.Where(o => o.Id == orderId).Select(order => new OrderRoomServiceDTO
            {
                orderId = order.Id,
                UserId = order.UserId,
                items = order.Items.Select(orderItems => new OrderItemDTO
                {
                    Id = orderItems.Id,
                    ItemName = orderItems.Item.ItemName,
                    note = orderItems.Note,
                    Price = orderItems.Price,
                    Quantity = orderItems.Quantity
                }).ToList(),
                Note = order.Note,
                createdAt = order.CreatedDate,
                status = order.Status
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderRoomServiceDTO>> GetOrdersByUserIdAsync(Guid userId)
        {
            return await _context.RoomServiceOrders
                .Where(o => o.UserId == userId)
                .Select(orders => new OrderRoomServiceDTO
                    {
                        orderId = orders.Id,
                        UserId = userId,
                        items = orders.Items.Select(orderItems => new OrderItemDTO
                        {
                            Id = orderItems.Id,
                            ItemName = orderItems.Item.ItemName,
                            note = orderItems.Note,
                            Price = orderItems.Price,
                            Quantity = orderItems.Quantity
                        }).ToList(),

                        Note = orders.Note,
                        createdAt = orders.CreatedDate,
                        status = orders.Status
                })
                .OrderByDescending(o => o.createdAt)
                .ToListAsync();
        }


        public async Task<RoomServiceOrderEntity?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _context.RoomServiceOrders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
