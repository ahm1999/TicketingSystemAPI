namespace TicketingSystem.Shared.Common
{
    public interface GenericRepository<T>
    {

        Task<T> Create(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Update(T entity);
        Task DeleteById(int Id);

    }
}
