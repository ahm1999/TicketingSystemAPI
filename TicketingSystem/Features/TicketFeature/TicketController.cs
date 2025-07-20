using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Features.TicketFeature.Interfaces;
using TicketingSystem.Features.UserFeature;


namespace TicketingSystem.Features.TicketFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IAuthService _authService;
        public TicketController(ITicketService ticketService, IAuthService authService)
        {
            _ticketService = ticketService;
            _authService = authService;
        }

        [HttpGet("AssignedTickets")]
        [Authorize(Roles = RolesConsts.Agent)]
        public async Task<IActionResult> GetAllAssignedTickets()
        {
            int UserId = _authService.GetCurrentUserId();

            var ServiceResponse = await _ticketService.GetAssignedTicketsForUser(UserId);

            return Ok(ServiceResponse);
        }

        [HttpGet]

        public async Task<IActionResult> GetTickets([FromQuery]TicketRequestQuery query) {

            var ticketResponse = await _ticketService.GetTickets(query);
            if (!ticketResponse.Success)
            {

                return BadRequest(ticketResponse);
            }
            return Ok(ticketResponse);



        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTicket(AddTicketDTO dto)
        {
            var ticketResponse = await _ticketService.AddTicketAsync(dto);

            return Ok(ticketResponse);

        }


        [HttpPost("AssignTicket/{TicketId:int}/{UserId}")]
        [Authorize(Roles = RolesConsts.Admin)]

        public async Task<IActionResult> AssingTicketToAgent(int TicketId, int UserId) {

            var ticketResponse = await _ticketService.AssignTicketToUser(UserId, TicketId);
            if (!ticketResponse.Success) {

                return BadRequest(ticketResponse);
            }
            return Ok(ticketResponse);
        }


        [HttpPost("{TicketId:int}/status/{ticketStatus}")]
        [Authorize(Roles =$"{RolesConsts.Agent},{RolesConsts.Admin}")]
        public async Task<IActionResult> ChangeTicketStatus(int TicketId,TicketStatus ticketStatus)
        {
            int UserId = _authService.GetCurrentUserId();

            var ticketResponse = await _ticketService.ChangeTicketStatus(TicketId, UserId, ticketStatus);
            if (!ticketResponse.Success)
            {

                return BadRequest(ticketResponse);
            }
            return Ok(ticketResponse);


        }


        [HttpGet("UnassignedTickets")]
        [Authorize(Roles = RolesConsts.Admin)]

        public async Task<IActionResult> GetAllUnAssignedTickets() {

            var ticketResponse = await _ticketService.GetAllUnAssignedTickets();
            if (!ticketResponse.Success)
            {

                return BadRequest(ticketResponse);
            }
            return Ok(ticketResponse);

        }


    }
}
