using BarkAvenueApi.Models;

namespace BarkAvenueApi.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpiryInHours { get; set; }
    }
}
