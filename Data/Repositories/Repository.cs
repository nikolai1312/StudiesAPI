using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Entities;

namespace StudiesAPI.Data.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly IContext _context;
        private readonly DbSet<TEntity> _entity;
        public IQueryable<TEntity> Entity => _entity;
        
        public Repository(IContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        
        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
