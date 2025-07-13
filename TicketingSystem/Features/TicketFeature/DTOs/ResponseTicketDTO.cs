namespace TicketingSystem.Features.TicketFeature.DTOs
{
    public class ResponseTicketDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? TicketStatus { get; set; }

        public int UserId { get; set; }

        public string? CreatedBy { get; set; }
        public string? Department { get; set; }

        public int? AssignedToId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? AssignedTo { get; set; }
    }
}
