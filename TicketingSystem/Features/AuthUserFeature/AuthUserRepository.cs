using TicketingSystem.Shared.Common;
using TicketingSystem.Features.AuthUserFeature;

namespace TicketingSystem.Features.AuthUserRepository
{
    public class AuthUserRepository : GenericRepository<AuthUser>
    {
        public Task<AuthUser> Create(AuthUser entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthUser> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthUser> Update(AuthUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
