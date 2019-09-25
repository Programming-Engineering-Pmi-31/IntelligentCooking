using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class UserToken: IdentityUserToken<int>, IIdentifiable<(int UserId, string LoginProvider, string Name)>
    {
        public (int UserId, string LoginProvider, string Name) Id => (UserId, LoginProvider, Name);
    }
}
