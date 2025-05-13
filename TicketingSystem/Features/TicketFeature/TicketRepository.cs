using Microsoft.EntityFrameworkCore;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.TicketFeature
{
    public class TicketRepository : AbsGenericRepository<Ticket>,IGenericRepository<Ticket>
    {
        public TicketRepository(ApplicationDBContext context) : base(context)
        {
        }
       
    }
}
