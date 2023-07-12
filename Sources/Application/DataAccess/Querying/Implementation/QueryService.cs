using Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.Querying.Implementation
{
    public class QueryService : IQueryService
    {
        private readonly IAppDbContextFactory _appDbContextFactory;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        public async Task<TResult> QueryAsync<TEntity, TResult>(Func<IQueryable<TEntity>, Task<TResult>> queryBuilder) where TEntity : EntityBase
        {
            using var appDbContext = _appDbContextFactory.Create();
            var dbSet = appDbContext.DbSet<TEntity>().AsNoTracking();

            return await queryBuilder(dbSet);
        }
    }
}