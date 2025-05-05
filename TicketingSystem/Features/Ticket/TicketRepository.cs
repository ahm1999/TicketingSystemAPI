using Microsoft.EntityFrameworkCore;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.Ticket
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        private readonly ApplicationDBContext _context;
        public TicketRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Ticket> Create(Ticket entity)
        {
            await _context.Tickets.AddAsync(entity);
            return entity;
        }

        public Task DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAll() => await _context.Tickets.ToListAsync();


        public Task<Ticket> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
