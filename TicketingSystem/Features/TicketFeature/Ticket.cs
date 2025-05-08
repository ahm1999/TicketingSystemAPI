using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.TicketFeature
{
    public class Ticket:BaseEntity
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public TicketStatus TicketStatus { get; set; } = TicketStatus.Open;

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
