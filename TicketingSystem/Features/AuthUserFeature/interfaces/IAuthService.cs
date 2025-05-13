using TicketingSystem.Features.AuthUserFeature.DTOs;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.AuthUserFeature.interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponse<LogInResponse>> LogInAsync(LogInDTO dto);
        public Task<ServiceResponse<SignUpResponse>> SignUpAsync(SignUpDTO dto);
    }
}
