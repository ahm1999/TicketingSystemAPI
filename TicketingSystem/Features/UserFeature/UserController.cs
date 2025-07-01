using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.UserFeature.Interfaces;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.UserFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{userId:int}/{DepartmentId:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddUserToDepartments([FromRoute]int userId,[FromRoute] int DepartmentId ) {

            ServiceResponse<User> Response = await _userService.AddDepartmentToUser(userId, DepartmentId);

            if (Response.Success)
            {
                return BadRequest(Response);
            }
            return Ok(Response);

        }
    }
}
