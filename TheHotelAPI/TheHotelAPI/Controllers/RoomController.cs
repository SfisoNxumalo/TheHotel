using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        //private readonly IRoomService _roomService;

        //public RoomController(IRoomService roomService)
        //{
        //    _roomService = roomService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllRooms()
        //{
        //    var rooms = await _roomService.GetAllRoomsAsync();
        //    return Ok(rooms);
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetRoom(Guid id)
        //{
        //    var room = await _roomService.GetRoomByIdAsync(id);
        //    if (room == null) return NotFound();
        //    return Ok(room);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddRoom([FromBody] RoomEntity room)
        //{
        //    var newRoom = await _roomService.AddRoomAsync(room);
        //    return CreatedAtAction(nameof(GetRoom), new { id = newRoom.Id }, newRoom);
        //}

        //[HttpPut("{id:guid}")]
        //public async Task<IActionResult> UpdateRoom(Guid id, [FromBody] RoomEntity room)
        //{
        //    if (id != room.Id) return BadRequest("ID mismatch");
        //    await _roomService.UpdateRoomAsync(room);
        //    return NoContent();
        //}

        //[HttpDelete("{id:guid}")]
        //public async Task<IActionResult> DeleteRoom(Guid id)
        //{
        //    await _roomService.DeleteRoomAsync(id);
        //    return NoContent();
        //}
    }
}
