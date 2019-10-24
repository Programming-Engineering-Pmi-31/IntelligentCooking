using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace InelligentCooking.BLL.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan JwtTokenLifetime { get; set; }
        public TimeSpan RefreshTokenLifetime { get; set; }

        public byte[] SecretBytes => Encoding.UTF8.GetBytes(Secret);
    }
}
