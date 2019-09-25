﻿using IntelligentCooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.Core.Entities
{
    public class Role: IdentityRole<int>, IIdentifiable<int>
    {
    }
}
