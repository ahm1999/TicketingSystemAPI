using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Shared.Interfaces;
using static TicketingSystem.Features.TicketFeature.TicketSpecification;

namespace TicketingSystem.Features.TicketFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var GetAllTickets = new GetAllTicketSpec(null);
            var tickets = await _unitOfWork.TicketRepository.ListAsync(GetAllTickets);
            return Ok(tickets);
        }

        [HttpGet("{userId:int}")]

        public async Task<IActionResult> GetTicketsUserId([FromRoute] int userId) {

            var ticketSpec = new GetAllTicketsByUserId(userId,null);

            var tickets = await _unitOfWork.TicketRepository.ListAsync(ticketSpec);

            return Ok(tickets); 
        
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTicket(Ticket ticket)
        {

            Ticket ticket1 = await _unitOfWork.TicketRepository.Create(ticket);
            await _unitOfWork.SaveChangesAsync();

            return Ok(ticket1);
        }
    }
}
