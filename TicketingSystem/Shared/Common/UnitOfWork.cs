using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Shared.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext _context;
        public GenericRepository<Ticket> TicketRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            TicketRepository = new TicketRepository(_context);


        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
