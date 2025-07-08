using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Features.TicketFeature.Interfaces;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Features.TicketFeature
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly ApplicationDBContext _context;
        public TicketService(IMapper mapper
                            ,IUnitOfWork unitOfWork
                            ,IAuthService authService
                            ,ApplicationDBContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
            _context = context;
        }
        public async Task<ServiceResponse<ResponseTicketDTO>> AddTicketAsync(AddTicketDTO dto)
        {
            Ticket ticket =  _mapper.Map<Ticket>(dto);

            ticket.UserId = _authService.GetCurrentUserId();

            await _context.Tickets.AddAsync(ticket);

            await _context.SaveChangesAsync();

            ResponseTicketDTO response = _mapper.Map<ResponseTicketDTO>(ticket);

            return new ServiceResponse<ResponseTicketDTO>(true, response, "ticket added Succesfully");
        }

        public Task<ServiceResponse<ResponseTicketDTO>> GetSingleTicketById()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ResponseTicketDTO>>> GetTicketsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ResponseTicketDTO>> AssignTicketToUser(int userId, int TicketId)
        {

            User? user = await _context.Users
                                .Include(u => u.Departments)
                                .FirstOrDefaultAsync(u => u.Id == userId);

            Ticket? ticket = await _context.Tickets
                                   .FirstOrDefaultAsync(t => t.Id == TicketId);

            if (user is null || ticket is null )
            {
                return new ServiceResponse<ResponseTicketDTO>(false, "Ticket or user doesn't exist ");

            }

            if (ticket.AssignedToId == userId) {

                return new ServiceResponse<ResponseTicketDTO>(false, "Ticket already assigned to user");

            }

            if (user.role != RolesConsts.Agent)
            {

                return new ServiceResponse<ResponseTicketDTO>(false, "user is not an agent");

            }

            if ( !user.Departments!.Any(d => d.Id ==ticket.DepartmentId))
            {

                return new ServiceResponse<ResponseTicketDTO>(false, "user is not an agent");

            }


            ticket.AssignedToId = user.Id;

            await _context.SaveChangesAsync();


            ResponseTicketDTO response = _mapper.Map<ResponseTicketDTO>(ticket);

            return new ServiceResponse<ResponseTicketDTO>(true, response, $"ticket assigned to user {user.Id}");




        }

        public async Task<ServiceResponse<List<ResponseTicketDTO>>> GetAssignedTicketsForUser(int userId)
        {
            List<ResponseTicketDTO> tickets = await _context.Tickets.Select<Ticket, ResponseTicketDTO>(t =>
                new ResponseTicketDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DepartmentId = t.DepartmentId,
                    UserId = t.UserId,
                    AssignedToId = t.AssignedToId,
                    TicketStatus = t.TicketStatus
                }
            ).Where(t => t.AssignedToId == userId)
             .ToListAsync();

            return new ServiceResponse<List<ResponseTicketDTO>>(true, tickets, "Tickets Retrieved Succesfully");
             
        }
    }
}
