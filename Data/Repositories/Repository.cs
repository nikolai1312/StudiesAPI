using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Entities;

namespace StudiesAPI.Data.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(TEntity _entity)
        {
            if(_entity is null)
            {
                throw new ArgumentNullException(nameof(_entity));
            }

            await _context.AddAsync(_entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity); 
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await GetAsync(id);
        }
    }
}
