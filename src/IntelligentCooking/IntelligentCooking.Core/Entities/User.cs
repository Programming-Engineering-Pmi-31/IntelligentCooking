using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class User: IdentityUser
    {
        public ICollection<Like> Likes { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }
}
