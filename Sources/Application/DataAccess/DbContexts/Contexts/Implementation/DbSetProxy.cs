using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts.Implementation
{
    public class DbSetProxy<TEntity> : IDbSetProxy<TEntity>
        where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IEntitySecurityDispatcher _securityDispatcher;

        public DbSetProxy(
            DbSet<TEntity> dbSet,
            IEntitySecurityDispatcher securityDispatcher)
        {
            _dbSet = dbSet;
            _securityDispatcher = securityDispatcher;
        }

        public async Task<EntityEntry<TEntity>> UpsertAsync(TEntity entity)
        {
            if (entity.Id == 0)
            {
                return await InsertAsync(entity);
            }

            return await UpdateAsync(entity);
        }

        private async Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity)
        {
            var authCheck = await _securityDispatcher.CheckAuthorizationAsync(EntityOperation.Update, entity);
            if (authCheck != EntityOperationCheckResult.Allowed)
            {
                throw new UnauthorizedAccessException("err");
            }

            return _dbSet.Update(entity);
        }


        private async Task<EntityEntry<TEntity>> InsertAsync(TEntity entity)
        {
            var authCheck = await _securityDispatcher.CheckAuthorizationAsync(EntityOperation.Insert, entity);
            if (authCheck != EntityOperationCheckResult.Allowed)
            {
                throw new UnauthorizedAccessException("err");
            }

            return await _dbSet.AddAsync(entity);
        }
        
        public IQueryable<TEntity> AsNoTracking()
        {
            return _securityDispatcher.AppendQuerySecurity(_dbSet).AsNoTracking();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var authCheck = await _securityDispatcher.CheckAuthorizationAsync(EntityOperation.Delete, entity);
            if (authCheck != EntityOperationCheckResult.Allowed)
            {
                throw new UnauthorizedAccessException("err");
            }

            _dbSet.Remove(entity);
        }
    }
}