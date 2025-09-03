namespace TicketingSystem.Features.UserFeature.Dtos
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? role { get; set; }
        public string? email { get; set; }
    }
}
