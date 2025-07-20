namespace TicketingSystem.Features.TicketFeature.DTOs
{
    public class TicketRequestQuery
    {



        //public DateTime? From { get;
        //    set {
        //        if (value is null) {
        //            From = DateTime.Now;
        //        }
        //    } }
        //public DateTime Until { get; set; }

        public int Page { get; set; } = 1;
        public int NumberOfTickets { get; set; } = 10;

        public TicketStatus? TicketStatus { get; set; }

        public bool? IsAssigned { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Untill { get; set; }



    }
}
