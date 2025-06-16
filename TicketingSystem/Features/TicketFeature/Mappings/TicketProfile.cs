using AutoMapper;
using TicketingSystem.Features.TicketFeature.DTOs;

namespace TicketingSystem.Features.TicketFeature.Mappings
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<AddTicketDTO, Ticket>();
            CreateMap<Ticket, ResponseTicketDTO>();
        }
    }
}
