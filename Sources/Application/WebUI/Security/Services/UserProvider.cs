using Mmu.EfCoreSecurity.Common.Security.Models;
using Mmu.EfCoreSecurity.Common.Security.Services;

namespace Mmu.EfCoreSecurity.WebUI.Security.Services
{
    public class UserProvider : IUserProvider
    {
        public LoggedInUser ProvideUser()
        {
            return new LoggedInUser(
                "admin",
                new List<Role>
                {
                    new Role(1, "Admin")
                });

            return new LoggedInUser(
                "user1",
                new List<Role>
                {
                    new Role(1, "user")
                });

        }
    }
}
