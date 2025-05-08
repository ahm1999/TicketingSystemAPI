using System.ComponentModel.DataAnnotations;
using TicketingSystem.Shared.Common;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.AuthUserFeature;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSystem.Features.UserFeature
{
    public class User:BaseEntity
    {
        [Required]
        public string? UserName  { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        [ForeignKey(nameof(AuthUser))]
        public int AuthUserId { get; set; }
        public AuthUser? AuthUser { get; set; }
    }
}
