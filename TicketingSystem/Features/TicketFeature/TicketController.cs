using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Features.TicketFeature.Interfaces;
using TicketingSystem.Shared.Interfaces;
using static TicketingSystem.Features.TicketFeature.TicketSpecification;

namespace TicketingSystem.Features.TicketFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(IUnitOfWork unitOfWork,ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok();
        }

        [HttpGet("{userId:int}")]

        public async Task<IActionResult> GetTicketsUserId([FromRoute] int userId) {



            return Ok(); 
        
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTicket(AddTicketDTO dto)
        {
            var ticketResponse = await _ticketService.AddTicketAsync(dto);

            return Ok(ticketResponse);

        }
    }
}
