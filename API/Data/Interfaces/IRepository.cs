using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
