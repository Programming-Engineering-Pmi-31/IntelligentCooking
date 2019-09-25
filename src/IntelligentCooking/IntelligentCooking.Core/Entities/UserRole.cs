using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class UserRole: IdentityUserRole<int>, IIdentifiable<(int UserId, int RoleId)>
    {
        public (int UserId, int RoleId) Id => (UserId, RoleId);
    }
}
