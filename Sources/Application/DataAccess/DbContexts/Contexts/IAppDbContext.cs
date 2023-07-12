using System.Diagnostics.CodeAnalysis;
using Mmu.EfCoreSecurity.DataAccess.Models.Base;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken token = default);

        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : EntityBase;
    }
}