using System.Linq.Expressions;

namespace TicketingSystem.Shared.Common
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }
        List<Expression<Func<T, object>>>? Includes { get; }
    }
}
