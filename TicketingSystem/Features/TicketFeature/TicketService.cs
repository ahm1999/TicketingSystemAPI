using AutoMapper;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.TicketFeature.DTOs;
using TicketingSystem.Features.TicketFeature.Interfaces;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Features.TicketFeature
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public TicketService(IMapper mapper
                            ,IUnitOfWork unitOfWork
                            ,IAuthService authService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }
        public async Task<ServiceResponse<ResponseTicketDTO>> AddTicketAsync(AddTicketDTO dto)
        {
            Ticket ticket =  _mapper.Map<Ticket>(dto);

            ticket.UserId = _authService.GetCurrentUserId();

            ticket = await _unitOfWork.TicketRepository.Create(ticket);

            await _unitOfWork.SaveChangesAsync();

            ResponseTicketDTO response = _mapper.Map<ResponseTicketDTO>(ticket);

            return new ServiceResponse<ResponseTicketDTO>(true, response, "ticket added Succesfully");
        }

        public Task<ServiceResponse<ResponseTicketDTO>> GetSingleTicketById()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ResponseTicketDTO>>> GetTicketsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
