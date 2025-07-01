using System.Linq.Expressions;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.UserFeature
{
    public static class UserSpecifications
    {

        public class GetUserWithIdSpecifcation : ISpecification<User>
        {
            private readonly int Id;

            public GetUserWithIdSpecifcation(int id, List<Expression<Func<User, object>>>? includes)
            {
                Id = id;
                Includes = Includes;
            }
            public Expression<Func<User, bool>>? Criteria => u => u.Id == Id;

            public List<Expression<Func<User, object>>>? Includes { get; }
        }
    }
}
