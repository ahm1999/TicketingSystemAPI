using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.UserFeature;

namespace TicketingSystem.Shared.Data
{
    public class ApplicationDBContext:DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasOne<AuthUser>(u => u.AuthUser)
                    .WithOne(au => au.User)
                    .IsRequired();
        }

        public DbSet<Ticket> Tickets { get; set; } 
        public DbSet<User> Users { get; set; } 
        
        public DbSet<AuthUser> AuthUsers { get; set; }
    }
}
