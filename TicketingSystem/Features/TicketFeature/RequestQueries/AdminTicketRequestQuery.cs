namespace TicketingSystem.Features.TicketFeature.RequestQueries
{
    public class AdminTicketRequestQuery:TicketRequestQuery
    {
        public bool? IsAssigned { get; set; }
        public int? AssignedToId { get; set; }
        public int? UserId { get; set; }
    }
}
