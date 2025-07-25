using System.ComponentModel.DataAnnotations;
using TicketingSystem.Shared.Common;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.AuthUserFeature;
using System.ComponentModel.DataAnnotations.Schema;
using TicketingSystem.Features.DepartmentFeature;
using TicketingSystem.Features.CommentFeature;

namespace TicketingSystem.Features.UserFeature
{
    public class User:BaseEntity
    {
        [Required]
        public string? UserName  { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Department>? Departments { get; set; } 

        [ForeignKey(nameof(AuthUser))]
        public int AuthUserId { get; set; }
        public AuthUser? AuthUser { get; set; }

        public string? role { get; set; } = RolesConsts.user;

        public ICollection<Ticket>? AssignedTickets { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
