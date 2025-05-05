using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.Ticket;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Shared.Common
{
    public static class ServiceRegisteration
    {
        public static void PersistanceDependancies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<GenericRepository<Ticket>, TicketRepository>();
        }
    }
}
