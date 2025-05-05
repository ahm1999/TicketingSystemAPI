using TicketingSystem.Features.Ticket;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Shared.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        GenericRepository<Ticket> TicketRepository { get; }
        Task SaveChangesAsync();
    }
}
