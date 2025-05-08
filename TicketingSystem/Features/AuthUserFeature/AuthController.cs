using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.AuthUserFeature.DTOs;

namespace TicketingSystem.Features.AuthUserFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO Dto) {

            return Ok();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO Dto)
        {

            return  Ok();
        }

    }
}
