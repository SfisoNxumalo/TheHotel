using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO user)
        {
            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserEntity user)
        {
            if (id != user.Id) return BadRequest("ID mismatch");
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userService.GetUserAsync();
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize]
        [HttpGet("staff")]
        public async Task<IActionResult> GetStaff()
        {
            var user = await _userService.GetStaffAsync();
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
