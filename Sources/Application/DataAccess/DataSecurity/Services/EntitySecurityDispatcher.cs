using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;

public class EntitySecurityDispatcher : IEntitySecurityDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EntitySecurityDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public async Task<EntityOperationCheckResult> CheckAuthorizationAsync<T>(EntityOperation operation, T entity)
        where T : EntityBase
    {
        return await GetHandler<T>().CheckOperationAsync(operation, entity);
    }

    public IQueryable<T> AppendQuerySecurity<T>(DbSet<T> set) where T : EntityBase
    {
        return GetHandler<T>().ApplySelectSecurity(set);
    }

    private IEntitySecurityHandler<T> GetHandler<T>()
        where T : EntityBase
    {
        var handler = _serviceProvider.GetService<IEntitySecurityHandler<T>>();
        if (handler == null) throw new Exception($"No handler for set {typeof(T).Name}.");

        return handler;
    }
}