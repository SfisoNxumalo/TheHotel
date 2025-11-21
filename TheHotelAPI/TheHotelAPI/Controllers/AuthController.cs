using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DomainExceptions;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.DTOs.UserDTO;

namespace TheHotelAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDTO loginModel)
        {
            try
            {
                var result = await _authService.Login(loginModel);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

                return Ok(result.UserDetails);
            }
            catch (DatabaseException DbE)
            {
                return StatusCode(500, DbE.Message);
            }
            catch (NoContentException NoCE)
            {
                return BadRequest(NoCE.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AddUserDTO user)
        {

            try
            {
                var result = await _authService.Register(user);
                if (result)
                {
                    return Ok("User registered successfully");
                }

                return Ok("unknown fail");
            }
            catch (DatabaseException DbE)
            {
                return StatusCode(500, DbE.Message);
            }
            catch (NoContentException NoCE)
            {
                return BadRequest(NoCE.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
