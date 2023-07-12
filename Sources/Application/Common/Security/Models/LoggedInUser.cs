namespace Mmu.EfCoreSecurity.Common.Security.Models
{
    public class LoggedInUser
    {
        public string UserId { get; }
        public IReadOnlyCollection<Role> UserRoles { get; }

        public bool IsAdmin => UserRoles.Select(f => f.RoleName).Contains("Admin");

        public LoggedInUser(string userId,
             IReadOnlyCollection<Role> userRoles)
        {
            UserId = userId;
            UserRoles = userRoles;
        }
    }
}
