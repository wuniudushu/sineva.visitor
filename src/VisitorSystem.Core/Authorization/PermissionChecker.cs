using Abp.Authorization;
using VisitorSystem.Authorization.Roles;
using VisitorSystem.Authorization.Users;

namespace VisitorSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
