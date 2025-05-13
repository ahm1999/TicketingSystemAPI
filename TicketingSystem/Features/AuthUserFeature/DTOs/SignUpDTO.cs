using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Features.AuthUserFeature.DTOs
{
    public record SignUpDTO {
        [Required]
        [EmailAddress]
        public string? Email  { get; set; }
        [Required]
        public string? UserName  { get; set; }
        [Required]
        public string? Password  { get; set; }

    }
    
}
