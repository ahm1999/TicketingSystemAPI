using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.AuthUserFeature.DTOs
{
    public class SignUpResponse 
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }
    }
}
