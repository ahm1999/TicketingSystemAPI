using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.DepartmentFeature;
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

            modelBuilder.Entity<User>()
                .HasMany<Department>(u => u.Departments)
                .WithMany(d => d.Users);
        }

        public DbSet<Ticket> Tickets { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
    }
}
