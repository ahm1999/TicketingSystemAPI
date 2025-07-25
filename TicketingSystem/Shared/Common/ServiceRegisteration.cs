using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.CommentFeature;
using TicketingSystem.Features.CommentFeature.Interfaces;
using TicketingSystem.Features.DepartmentFeature;
using TicketingSystem.Features.DepartmentFeature.Interfaces;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.TicketFeature.Interfaces;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Features.UserFeature.Interfaces;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;
using TicketingSystem.Shared.Utils;
using TicketingSystem.Shared.Utils.TokenServices;

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
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Program));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddTransient<IPasswordHashing, PasswordHashing>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
