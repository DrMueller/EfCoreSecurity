using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.Common.Security.Services;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Models;
using Mmu.EfCoreSecurity.DataAccess.Models;

namespace Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services.Strategies;

public class AgendaHandler : IEntitySecurityHandler<Agenda>
{
    private readonly IUserProvider _userProvider;

    public AgendaHandler(IUserProvider userProvider)
    {
        _userProvider = userProvider;
    }

    public IQueryable<Agenda> ApplySelectSecurity(DbSet<Agenda> set)
    {
        if (_userProvider.ProvideUser().IsAdmin) return set.AsQueryable();
        return set.Where(f => f.CreatedUserId == _userProvider.ProvideUser().UserId);
    }

    public Task<EntityOperationCheckResult> CheckOperationAsync<T>(EntityOperation operation, T entity)
    {
        if (_userProvider.ProvideUser().IsAdmin) return Task.FromResult(EntityOperationCheckResult.Allowed);

        return Task.FromResult(EntityOperationCheckResult.Disallowed);
    }
}