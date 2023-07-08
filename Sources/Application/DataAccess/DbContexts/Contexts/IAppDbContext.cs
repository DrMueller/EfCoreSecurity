using System.Diagnostics.CodeAnalysis;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable
    {
        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : class;
    }
}