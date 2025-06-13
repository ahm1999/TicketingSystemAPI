using System.Linq.Expressions;

namespace TicketingSystem.Shared.Common
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity, new()
    {


        public Expression<Func<T, bool>>? Criteria { get; set; }

        public List<Expression<Func<T, object>>>? Includes => throw new NotImplementedException();

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
