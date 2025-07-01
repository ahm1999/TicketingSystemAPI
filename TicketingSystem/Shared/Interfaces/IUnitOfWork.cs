using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.DepartmentFeature;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Shared.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Ticket> TicketRepository { get; }
        IGenericRepository<AuthUser> AuthUserRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        Task SaveChangesAsync();
    }
}
