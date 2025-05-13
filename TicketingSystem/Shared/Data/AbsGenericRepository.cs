using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Shared.Common;


namespace TicketingSystem.Shared.Data
{
    public abstract class AbsGenericRepository<T> :IGenericRepository<T> where T : BaseEntity,new()
    {
        private readonly ApplicationDBContext _context;

        private DbSet<T> entities;

        protected AbsGenericRepository(ApplicationDBContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await entities.AddAsync(entity);
            return entity;
        }

        public Task DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            IQueryable<T> query = entities;

            if (spec.Criteria is not null)
            {
                query =  query.Where(spec.Criteria);

            }

            return await query.ToListAsync();
            
        }

        public async Task<T> GetSingleEntity(ISpecification<T> spec) {

        if (spec.Criteria is null) return BaseEntity.Empty<T>();
        T? response = await entities.FirstOrDefaultAsync(spec.Criteria);
        if (response is null) return BaseEntity.Empty<T>();
          
        return response;

        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
