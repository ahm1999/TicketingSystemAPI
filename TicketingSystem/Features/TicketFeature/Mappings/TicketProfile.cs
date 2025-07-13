using AutoMapper;
using TicketingSystem.Features.TicketFeature.DTOs;

namespace TicketingSystem.Features.TicketFeature.Mappings
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<AddTicketDTO, Ticket>();
            CreateMap<Ticket, ResponseTicketDTO>()
                .ForMember(dto => dto.Department, opt => opt.MapFrom(src => src.department ))
                .ForMember(dto => dto.CreatedBy, opt => opt.MapFrom(src => src.User!.UserName ))
                .ForMember(dto => dto.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo!.UserName))
                .ForMember(dto => dto.TicketStatus, opt => opt.MapFrom(src => src.TicketStatus.ToString()));
        }
    }
}
