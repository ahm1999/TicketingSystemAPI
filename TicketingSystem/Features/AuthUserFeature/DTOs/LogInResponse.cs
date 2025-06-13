namespace TicketingSystem.Features.AuthUserFeature.DTOs
{
    public class LogInResponse
    {
        public string? Token { get; set; }

        public LogInResponse(string token)
        {
            this.Token = token;
        }
    }
}
