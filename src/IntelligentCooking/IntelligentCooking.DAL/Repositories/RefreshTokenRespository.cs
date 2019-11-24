using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class RefreshTokenRespository : Repository<RefreshToken, string>, IRefreshTokenRepository
    {
        public RefreshTokenRespository(IntelligentCookingContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync()
        {
            return await Context.RefreshTokens.Where(t => t.IsInvalidated || t.IsUsed || t.ExpirationDate < DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
