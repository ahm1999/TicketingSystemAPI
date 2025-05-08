using System.ComponentModel.DataAnnotations;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.AuthUserFeature
{
    public class AuthUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public User? User { get; set; }
    }
}
