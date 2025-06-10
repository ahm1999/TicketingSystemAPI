using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Features.AuthUserFeature.DTOs
{
    public class LogInDTO
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
