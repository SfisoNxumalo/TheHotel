using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomServiceOrderController : ControllerBase
    {
        private readonly IRoomServiceOrderService _orderService;

        public RoomServiceOrderController(IRoomServiceOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("booking/{bookingId:guid}")]
        public async Task<IActionResult> GetOrdersForBooking(Guid bookingId)
        {
            var orders = await _orderService.GetOrdersForBookingAsync(bookingId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] RoomServiceOrderEntity order)
        {
            var created = await _orderService.PlaceOrderAsync(order);
            return CreatedAtAction(nameof(GetOrdersForBooking), new { bookingId = order.BookingId }, created);
        }

        [HttpPatch("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromQuery] string status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return NoContent();
        }
    }
}
