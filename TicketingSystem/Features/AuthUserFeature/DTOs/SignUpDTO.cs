using System.ComponentModel.DataAnnotations;
using TicketingSystem.Features.UserFeature;

namespace TicketingSystem.Features.AuthUserFeature.DTOs
{
    public record SignUpDTO {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

        [Required]
        [AllowedValues(RolesConsts.user, RolesConsts.Agent, RolesConsts.Admin)]
        public string? Role { get; set; }

    }
    
}
