using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.DepartmentFeature
{
    public class DepartmentRepository : AbsGenericRepository<Department>, IGenericRepository<Department>
    {
        public DepartmentRepository(ApplicationDBContext context) : base(context)
        {
        }

    }
}
