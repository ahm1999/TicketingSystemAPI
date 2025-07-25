namespace TicketingSystem.Features.TicketFeature.RequestQueries
{
    public class TicketRequestQuery
    {


        public int Page { get; set; } = 1;
        public int NumberOfTickets { get; set; } = 10;

        public TicketStatus? TicketStatus { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Untill { get; set; }

    }
}
