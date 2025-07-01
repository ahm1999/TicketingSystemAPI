using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.DepartmentFeature
{
    public class Department:BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; } 

    }
}
