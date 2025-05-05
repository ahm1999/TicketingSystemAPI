using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.Ticket;

namespace TicketingSystem.Shared.Data
{
    public class ApplicationDBContext:DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

        public DbSet<Ticket> Tickets { get; set; } 
    }
}
