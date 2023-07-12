using Mmu.EfCoreSecurity.Common.Security.Models;

namespace Mmu.EfCoreSecurity.Common.Security.Services
{
    public interface IUserProvider
    {
        LoggedInUser ProvideUser();
    }
}
