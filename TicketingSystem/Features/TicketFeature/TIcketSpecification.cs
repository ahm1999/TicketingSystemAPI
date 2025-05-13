using System.Linq.Expressions;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.TicketFeature
{
    public static class TicketSpecification
    {
        public class FindTicketByIdSpec : ISpecification<Ticket>
        {
            private readonly int _Id;
            public FindTicketByIdSpec(int id)
            {
                _Id = id;
            }
            public Expression<Func<Ticket, bool>>? Criteria => t => t.Id == _Id;
        }

        public class GetAllTicketSpec : ISpecification<Ticket>
        {
            public Expression<Func<Ticket, bool>>? Criteria => null;
        }

        public class GetAllTicketsByUserId : ISpecification<Ticket>
        {
            private readonly int _userId;

            public GetAllTicketsByUserId(int userId)
            {
                _userId = userId;
            }
            public Expression<Func<Ticket, bool>>? Criteria => t => t.UserId ==_userId;
        }
    }
}
