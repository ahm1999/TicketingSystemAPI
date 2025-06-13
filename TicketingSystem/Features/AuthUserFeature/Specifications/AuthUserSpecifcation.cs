using System.Linq.Expressions;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.AuthUserFeature.Specifications
{
    public static class AuthUserSpecifcation
    {
        public class FindByEmailSpecification : ISpecification<AuthUser>
        {
            private readonly string _email;

            public FindByEmailSpecification(string Email, List<Expression<Func<AuthUser, object>>>? includes)
            {
                _email = Email;
                Includes = includes;
            }
            public Expression<Func<AuthUser, bool>>? Criteria => au =>au.Email == _email;

            public List<Expression<Func<AuthUser, object>>>? Includes { get; }

        }
    }
}
