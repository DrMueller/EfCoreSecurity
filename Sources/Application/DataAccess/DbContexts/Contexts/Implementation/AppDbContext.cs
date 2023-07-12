using Microsoft.EntityFrameworkCore;
using Mmu.EfCoreSecurity.DataAccess.DataSecurity.Services;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts.Implementation;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IEntitySecurityDispatcher _securityDispatcher;

    public AppDbContext(
        DbContextOptions options,
        IEntitySecurityDispatcher securityDispatcher)
        : base(options)
    {
        _securityDispatcher = securityDispatcher;
    }

    public IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : EntityBase
    {
        var set = Set<TEntity>();
        return new DbSetProxy<TEntity>(set, _securityDispatcher);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        //modelBuilder.Entity<Meeting>()
        //    .HasQueryFilter(f => f.Agenda != null && f.Agenda.CreatedUserId == _userProvider.ProvideUser().UserId);

        //modelBuilder.Entity<Agenda>()
        //    .HasQueryFilter(entity => entity.CreatedUserId == _userProvider.ProvideUser().UserId);
    }
}