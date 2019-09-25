using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class UserClaim: IdentityUserClaim<int>, IIdentifiable<int>
    {
        
    }
}
