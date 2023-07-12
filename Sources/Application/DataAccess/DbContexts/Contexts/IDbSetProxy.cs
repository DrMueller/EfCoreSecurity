using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts
{
    public interface IDbSetProxy<TEntity>
        where TEntity : class
    {
        Task<EntityEntry<TEntity>> UpsertAsync(TEntity entity);

        IQueryable<TEntity> AsNoTracking();

        Task RemoveAsync(TEntity entity);
    }
}