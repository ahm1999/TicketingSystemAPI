using TicketingSystem.Features.CommentFeature.Dtos;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.CommentFeature.Interfaces
{
    public interface ICommentService
    {

        Task<ServiceResponse<CommentResponseDTO>> AddComment(int UserId, int TicketId, AddCommentDTO dto);

        Task<ServiceResponse<List<CommentResponseDTO>>> GetComments(int TicketId);

    }
}
