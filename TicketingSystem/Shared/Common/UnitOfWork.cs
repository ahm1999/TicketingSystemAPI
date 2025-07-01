using TicketingSystem.Features.AuthUserFeature;
using TicketingSystem.Features.AuthUserRepository;
using TicketingSystem.Features.DepartmentFeature;
using TicketingSystem.Features.TicketFeature;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Shared.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext _context;
        public IGenericRepository<Ticket> TicketRepository { get; private set; }
        public IGenericRepository<AuthUser> AuthUserRepository { get; private set; }
        public IGenericRepository<User> UserRepository { get; private set; }
        public IGenericRepository<Department> DepartmentRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            TicketRepository = new TicketRepository(_context);
            AuthUserRepository = new AuthUserRepository(_context);
            UserRepository = new UserRepository(_context);
            DepartmentRepository = new DepartmentRepository(_context);  

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
