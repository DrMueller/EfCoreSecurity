using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;

public interface IEntitySecurityHandler<T>
    where T : EntityBase
{
    IQueryable<T> ApplySelectSecurity(DbSet<T> set);

    Task<EntityOperationCheckResult> CheckOperationAsync<T>(EntityOperation operation, T entity);
}