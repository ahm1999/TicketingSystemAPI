using TicketingSystem.Features.AuthUserFeature;
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
        Task SaveChangesAsync();
    }
}
