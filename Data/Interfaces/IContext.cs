using Microsoft.EntityFrameworkCore;

namespace StudiesAPI.Data.Interfaces
{
    public interface IContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
