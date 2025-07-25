using System.ComponentModel.DataAnnotations.Schema;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.CommentFeature
{
    
    public class Comment:BaseEntity
    {
        public string? Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AddedById { get; set; }

        public User? AddedBy { get; set; }

        public int TicketId { get; set; }

        public Ticket? Ticket { get; set; }
    }
}
