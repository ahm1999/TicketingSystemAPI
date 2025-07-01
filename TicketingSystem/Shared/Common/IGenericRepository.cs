using System.Linq.Expressions;

namespace TicketingSystem.Shared.Common
{
    public interface IGenericRepository<T>
    {

        Task<T> Create(T entity);
        Task<List<T>> ListAsync(ISpecification<T>? specification);
        Task<T> GetSingleEntity(ISpecification<T>? specification);
        Task<T> GetEntityById(int Id);
        T Update(T entity);
        Task DeleteById(int Id);

    }
}
