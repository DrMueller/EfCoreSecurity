using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.Querying;

public interface IQueryService
{
    Task<TResult> QueryAsync<TEntity, TResult>(Func<IQueryable<TEntity>, Task<TResult>> queryBuilder)
        where TEntity : EntityBase;
}