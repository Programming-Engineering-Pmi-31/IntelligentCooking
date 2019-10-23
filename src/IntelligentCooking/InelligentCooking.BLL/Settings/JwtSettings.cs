using System;

namespace InelligentCooking.BLL.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan JwtTokenLifetime { get; set; }
        public TimeSpan RefreshTokenLifetime { get; set; }
    }
}
