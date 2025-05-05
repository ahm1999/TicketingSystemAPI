using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.Ticket
{
    public class Ticket:BaseEntity
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
