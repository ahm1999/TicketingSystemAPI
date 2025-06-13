using System.Linq.Expressions;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.TicketFeature
{
    public static class TicketSpecification
    {
        public class FindTicketByIdSpec : ISpecification<Ticket>
        {
            private readonly int _Id;
            public FindTicketByIdSpec(int id, List<Expression<Func<Ticket, object>>>? includes)
            {
                _Id = id;
                Includes = includes;
            }
            public Expression<Func<Ticket, bool>>? Criteria => t => t.Id == _Id;

            public List<Expression<Func<Ticket, object>>>? Includes {get ;}
        }



        public class GetAllTicketSpec : ISpecification<Ticket>
        {
            public GetAllTicketSpec(List<Expression<Func<Ticket, object>>>? includes)
            {
                Includes = includes;
            }
            public Expression<Func<Ticket, bool>>? Criteria => null;

            public List<Expression<Func<Ticket, object>>>? Includes { get; }

        }



        public class GetAllTicketsByUserId : ISpecification<Ticket>
        {
            private readonly int _userId;

            public GetAllTicketsByUserId(int userId,List<Expression<Func<Ticket,object>>>? includes)
            {
                _userId = userId;
                Includes = includes;
            }
            public Expression<Func<Ticket, bool>>? Criteria => t => t.UserId ==_userId;

            public List<Expression<Func<Ticket, object>>>? Includes { get; }

        }
    }
}
