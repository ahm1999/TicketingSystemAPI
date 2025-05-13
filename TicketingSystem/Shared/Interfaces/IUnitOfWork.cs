using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Shared.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Ticket> TicketRepository { get; }
        IGenericRepository<AuthUser> AuthUserRepository { get; }
        Task SaveChangesAsync();
    }
}
