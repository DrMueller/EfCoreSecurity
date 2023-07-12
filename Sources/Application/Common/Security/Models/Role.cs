namespace Mmu.EfCoreSecurity.Common.Security.Models
{
    public class Role
    {
        public int RoleId { get; }
        public string RoleName { get; }

        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }

    }
}
