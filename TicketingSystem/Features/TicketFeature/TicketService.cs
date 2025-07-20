using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
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

            ticket.CreatedOn = DateTime.Now;

            ticket.UserId = _authService.GetCurrentUserId();

            await _context.Tickets.AddAsync(ticket);

            await _context.SaveChangesAsync();

            //var ret_Ticket = _context.Tickets
            //                         .Include(t => t.User )
            //                         .Include(t => t.department )
            //                         .FirstOrDefaultAsync(t => t.Id == ticket.Id);

            


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
                    Department = t.department!.Name,
                    UserId = t.UserId,
                    AssignedTo = t.AssignedTo!.UserName,
                    AssignedToId = t.AssignedToId,
                    TicketStatus = t.TicketStatus.ToString(),
                    CreatedBy = t.User!.UserName
                    
                }
            ).Where(t => t.AssignedToId == userId)
             .ToListAsync();

            return new ServiceResponse<List<ResponseTicketDTO>>(true, tickets, "Tickets Retrieved Succesfully");
             
        }

        public async Task<ServiceResponse<ResponseTicketDTO>> ChangeTicketStatus(int TicketId,int UserId ,TicketStatus ticketStatus)
        {
            User? user = await _context.Users
                               .Include(u => u.Departments)
                               .FirstOrDefaultAsync(u => u.Id == UserId);

            Ticket? ticket = await _context.Tickets
                                   .FirstOrDefaultAsync(t => t.Id == TicketId);

            if (user is null || ticket is null)
            {
                return new ServiceResponse<ResponseTicketDTO>(false, "Ticket or user doesn't exist ");

            }


            bool IsAdmin = user.role == RolesConsts.Admin;
            bool IsAgent = user.role == RolesConsts.Agent;


            if (ticket.AssignedToId != UserId && !IsAdmin)
            {

                return new ServiceResponse<ResponseTicketDTO>(false, "Ticket not assigned to user");

            }

            if (ticket.TicketStatus == TicketStatus.Closed)
            {
                return new ServiceResponse<ResponseTicketDTO>(false, "Ticket is closed by Admin");
            }


            if (ticketStatus == TicketStatus.Closed && IsAgent )
            {
                return new ServiceResponse<ResponseTicketDTO>(false, "An Agent Can't close a ticket");
            }

            if (ticketStatus != TicketStatus.Closed && IsAdmin)
            {
                return new ServiceResponse<ResponseTicketDTO>(false, "An Admin Can only close a ticket");
            }


            ticket.TicketStatus = ticketStatus;

            await _context.SaveChangesAsync();

            ResponseTicketDTO response = _mapper.Map<ResponseTicketDTO>(ticket);
            return new ServiceResponse<ResponseTicketDTO>(true, response, $"ticket changed status {ticketStatus.ToString()}");


        }

        public async Task<ServiceResponse<List<ResponseTicketDTO>>> GetAllUnAssignedTickets()
        {
            List<Ticket> tickets = await _context.Tickets
                                   .Include(t => t.department)
                                   .Include(t => t.User)
                                   .Include(t => t.AssignedTo)
                                   .Where(t => t.AssignedToId == null)
                                   .ToListAsync();

            List<ResponseTicketDTO> responseTicketDTOs = _mapper.Map<List<ResponseTicketDTO>>(tickets);

            return new ServiceResponse<List<ResponseTicketDTO>>(true, responseTicketDTOs, "tickets retrieved");
        }

        public async Task<ServiceResponse<List<ResponseTicketDTO>>> GetTickets(TicketRequestQuery query)
        {
            IQueryable<Ticket> tickets = _context.Tickets
                                                 .Include(t => t.department)
                                                 .Include(t => t.User)
                                                 .Include(t => t.AssignedTo);






            if (query.TicketStatus is not null)
            {
                tickets = tickets.Where(t => t.TicketStatus == query.TicketStatus);
            }

            if (query.IsAssigned is not null) {

                tickets = tickets.Where(t => t.AssignedToId != null);
            
            }

            if (query.From is not null && query.Untill is not null) {

                tickets = tickets.Where(t => t.CreatedOn >=query.From || t.CreatedOn <= query.Untill );
            }

            tickets = tickets.OrderByDescending(t => t.Id);

            tickets = tickets.Skip((query.Page - 1) * query.NumberOfTickets)
                             .Take(query.NumberOfTickets);


            var ticketsList = await tickets
                                    .AsNoTracking()
                                    .ToListAsync();

            List<ResponseTicketDTO> responseTicketDTOs = _mapper.Map<List<ResponseTicketDTO>>(ticketsList);

            return new ServiceResponse<List<ResponseTicketDTO>>(true, responseTicketDTOs, "tickets retrieved");

        }
    }
}
