using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.AuthUserFeature.DTOs;
using TicketingSystem.Features.AuthUserFeature.interfaces;

namespace TicketingSystem.Features.AuthUserFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO Dto) {

            var response = await _authService.LogInAsync(Dto);

            return Ok(response);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO Dto)
        {
            var response = await _authService.SignUpAsync(Dto);

            return  Ok(response);
        }

    }
}
