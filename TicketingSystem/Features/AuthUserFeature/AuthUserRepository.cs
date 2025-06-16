using TicketingSystem.Shared.Common;
using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Shared.Data;


namespace TicketingSystem.Features.AuthUserRepository
{
    public class AuthUserRepository : AbsGenericRepository<AuthUser>,IGenericRepository<AuthUser>
    {
        public AuthUserRepository(ApplicationDBContext context):base(context)
        {   
        }
    }
}
