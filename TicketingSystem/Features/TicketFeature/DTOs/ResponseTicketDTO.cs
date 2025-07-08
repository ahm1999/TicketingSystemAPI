namespace TicketingSystem.Features.TicketFeature.DTOs
{
    public class ResponseTicketDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public TicketStatus TicketStatus { get; set; } 

        public int UserId { get; set; }

        public int DepartmentId { get; set; }

        public int? AssignedToId { get; set; }
    }
}
