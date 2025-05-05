using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.Ticket;
using TicketingSystem.Shared;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Shared.Common
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

            return Ok(await _unitOfWork.TicketRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(Ticket ticket)
        {

            Ticket ticket1 = await _unitOfWork.TicketRepository.Create(ticket);
            await _unitOfWork.SaveChangesAsync();

            return Ok(ticket1);
        }
    }
}
