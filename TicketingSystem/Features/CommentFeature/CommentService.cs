using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.CommentFeature.Dtos;
using TicketingSystem.Features.CommentFeature.Interfaces;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.CommentFeature
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CommentService(ApplicationDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CommentResponseDTO>> AddComment(int UserId, int TicketId, AddCommentDTO dto)
        {
            //check if the user or the admin or ao the agenet assigned this ticket
            Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == TicketId);
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);


            if (ticket is null|| user is null)
            {
                return new ServiceResponse<CommentResponseDTO>(false, "Ticket doesn't exist");
            }

            //check if the user or the admin or ao the agenet assigned this ticket

            bool IsAdmin = user.role == RolesConsts.Admin;
            bool IsAgentAssignedToTicekt = user.role == RolesConsts.Agent && ticket.AssignedToId == UserId;
            bool IsUserCreatedTheTicket = user.role == RolesConsts.user && ticket.UserId == UserId;

            if (!(IsUserCreatedTheTicket || IsAgentAssignedToTicekt || IsAdmin)) {

                return new ServiceResponse<CommentResponseDTO>(false, "UnAuthorized");

            }

            Comment comment = _mapper.Map<Comment>(dto);

            comment.AddedById = UserId;
            comment.CreatedOn = DateTime.Now;   
            comment.TicketId = ticket.Id;
            
            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();


            CommentResponseDTO commentResponse = _mapper.Map<CommentResponseDTO>(comment);
            commentResponse.AddedBy = user.UserName;


            return new ServiceResponse<CommentResponseDTO>(true, commentResponse, "Comment Added Succesfully");


        }

        public async Task<ServiceResponse<List<CommentResponseDTO>>> GetComments(int TicketId)
        {
            //var Comments = await _context.Comments
            //                             .Where(c=> c.TicketId == TicketId )
            //                             .ToListAsync();

            //List<CommentResponseDTO> Response = _mapper.Map<List<CommentResponseDTO>>(Comments);  

            List<CommentResponseDTO> Response = await _mapper.ProjectTo<CommentResponseDTO>(_context.Comments
                                                                                     .Where(c => c.TicketId == TicketId)
                                                                                     , null).ToListAsync();


            return new ServiceResponse<List<CommentResponseDTO>>(true, Response, "Comments Retrieved Succesfully");
        }
    }
}
