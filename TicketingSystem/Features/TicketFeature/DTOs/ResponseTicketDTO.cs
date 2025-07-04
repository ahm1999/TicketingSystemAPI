﻿namespace TicketingSystem.Features.TicketFeature.DTOs
{
    public class ResponseTicketDTO
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public TicketStatus TicketStatus { get; set; } 

        public int UserId { get; set; }
    }
}
