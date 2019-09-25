using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class UserLogin: IdentityUserLogin<int>, IIdentifiable<(string LoginProvider, string ProviderKey)>
    {
        public (string LoginProvider, string ProviderKey) Id => (LoginProvider, ProviderKey);
    }
}
