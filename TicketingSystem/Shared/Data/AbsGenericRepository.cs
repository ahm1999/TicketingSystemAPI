using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Shared.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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

        public async Task<List<T>> ListAsync(ISpecification<T>? spec)
        {
            IQueryable<T> query = entities;

            if (spec is null) { 
                return await query.ToListAsync();
            }

           

            if (spec.Criteria is not null)
            {
                query =  query.Where(spec.Criteria);

            }

            if (spec.Includes is not null) {

                foreach (var item in spec.Includes)
                {
                   query = query.Include(item);
                }

            }

            return await query.ToListAsync();
            
        }

        public async Task<T> GetSingleEntity(ISpecification<T>? spec) {

            IQueryable <T> query = entities;

            if (spec is null)
            {
                return BaseEntity.Empty<T>();
            }


            if (spec.Criteria is null) return BaseEntity.Empty<T>();

            if (spec.Includes is not null)
            {
                foreach (var item in spec.Includes)
                {
                    query = query.Include(item);
                }
            }

            T? response = await query.FirstOrDefaultAsync(spec.Criteria);

            if (response is null) return BaseEntity.Empty<T>();
          
            return response;
        }

        public async Task<T> GetEntityById(int Id) {

            IQueryable<T> query = entities;

            var entity = await query.FirstOrDefaultAsync(e => e.Id == Id);

            if (entity is null) {
                return BaseEntity.Empty<T>();

            }

            return entity;
        }


        public T Update(T entity)
        {
            entities.Update(entity);


            return entity;
        }

        
    }
}
