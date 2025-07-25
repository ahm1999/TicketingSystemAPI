namespace TicketingSystem.Features.CommentFeature.Dtos
{
    public class CommentResponseDTO
    {
        public string? Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AddedById { get; set; }

        public string? AddedBy { get; set; }

        public int TicketId { get; set; }
    }
}
