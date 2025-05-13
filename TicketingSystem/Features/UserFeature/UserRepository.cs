using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.UserFeature
{
    public class UserRepository:AbsGenericRepository<User>,IGenericRepository<User>
    {
        public UserRepository(ApplicationDBContext context):base(context)
        {
            
        }
    }
}
