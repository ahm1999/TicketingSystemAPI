using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.UserFeature.Interfaces;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.UserFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("{userId:int}/{DepartmentId:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddUserToDepartments([FromRoute]int userId,[FromRoute] int DepartmentId ) {

            ServiceResponse<User> Response = await _userService.AddDepartmentToUser(userId, DepartmentId);

            if (!Response.Success)
            {
                return BadRequest(Response);
            }
            return Ok(Response);

        }

        [HttpGet("Current")]
        [Authorize]
        public async Task<IActionResult> CurrentUser() {

            int UserId = _authService.GetCurrentUserId();

            var response = await _userService.GetUserData(UserId);


            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);


        }

    }
}
