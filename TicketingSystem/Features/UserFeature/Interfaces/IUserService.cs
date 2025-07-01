using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.UserFeature.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> AddDepartmentToUser(int UserId,int DepartmentId);
    }
}
