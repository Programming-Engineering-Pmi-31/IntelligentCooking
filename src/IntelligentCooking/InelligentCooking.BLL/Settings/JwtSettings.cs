using System;

namespace InelligentCooking.BLL.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}
