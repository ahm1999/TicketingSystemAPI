using AutoMapper;
using TicketingSystem.Features.CommentFeature.Dtos;


namespace TicketingSystem.Features.CommentFeature.Mappings
{
    public class CommentProfile : Profile
    {

        public CommentProfile()
        {
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentResponseDTO>()
                .ForMember(dto => dto.AddedBy, opt => opt.MapFrom(src => src.AddedBy!.UserName));
        }
    }
}
