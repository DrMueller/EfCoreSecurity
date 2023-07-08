using Mmu.EfCoreSecurity.DataAccess.DbContexts.Contexts;

namespace Mmu.EfCoreSecurity.DataAccess.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}