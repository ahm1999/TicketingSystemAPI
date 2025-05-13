using System.Linq.Expressions;

namespace TicketingSystem.Shared.Common
{
    public interface ISpecification<T>
    {
        public Expression<Func<T,bool>>? Criteria { get;  }
    }
}
