using TicketingSystem.Features.DepartmentFeature;
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

        public int DepartmentId { get; set; }

        public Department? department { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }
    }
}
