using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Data.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
