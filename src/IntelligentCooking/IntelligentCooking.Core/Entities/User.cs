using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }
}
