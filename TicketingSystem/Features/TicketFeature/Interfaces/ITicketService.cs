using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.TicketFeature.Interfaces
{
    public interface ITicketService
    {
        Task<ServiceResponse<ResponseTicketDTO>> AddTicketAsync(AddTicketDTO dto);
        Task<ServiceResponse<ResponseTicketDTO>> GetSingleTicketById();
        Task<ServiceResponse<List<ResponseTicketDTO>>> GetTicketsByUser (int userId);
        Task<ServiceResponse<List<ResponseTicketDTO>>> GetTickets (TicketRequestQuery query);

        

        Task<ServiceResponse<ResponseTicketDTO>> AssignTicketToUser(int userId, int TicketId);
        Task<ServiceResponse<ResponseTicketDTO>> ChangeTicketStatus(int TicketId,int UserId,TicketStatus ticketStatus);
        Task<ServiceResponse<List<ResponseTicketDTO>>> GetAssignedTicketsForUser (int userId);
        Task<ServiceResponse<List<ResponseTicketDTO>>> GetAllUnAssignedTickets ();

    }
}
