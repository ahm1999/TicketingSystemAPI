using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.CommentFeature.Dtos;
using TicketingSystem.Features.CommentFeature.Interfaces;
using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Features.UserFeature.Interfaces;

namespace TicketingSystem.Features.CommentFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;
        private readonly IAuthService _authService;

        public CommentController(IAuthService authService,ICommentService commentService)
        {
            
            _commentService = commentService;
            _authService = authService;
        }

        [Authorize]
        [HttpGet("Ticket/{TicketId:int}")]
        public async Task<IActionResult> GetComments([FromRoute] int TicketId)
        {
            var response = await _commentService.GetComments(TicketId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [Authorize]
        [HttpPost("Ticket/{TicketId:int}")]
        public async Task<IActionResult> AddComment([FromRoute]int TicketId  ,AddCommentDTO dTO) {

            int UserId = _authService.GetCurrentUserId();

            var response = await _commentService.AddComment(UserId,TicketId,dTO);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [Authorize]
        [HttpDelete("{CommentId:int}")]

        public async Task<IActionResult> DeleteComment([FromRoute] int CommentId) {


            return Ok();
        }




    }
}
