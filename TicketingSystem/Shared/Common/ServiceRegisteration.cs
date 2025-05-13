using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.TicketFeature;
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

        public static void Services(this IServiceCollection services) {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
