using System.Collections.Generic;
using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class User: IdentityUser<int>, IIdentifiable<int>
    {
        public ICollection<Like> Likes { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }
}
