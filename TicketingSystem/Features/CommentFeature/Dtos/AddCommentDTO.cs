using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Features.CommentFeature.Dtos
{
    public class AddCommentDTO
    {
        [Required]
        public string? Content { get; set; }

        
    }
}
