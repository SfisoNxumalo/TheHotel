using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Infrastructure.Integration.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string AccessTokenSecret { get; set; } = string.Empty;
        public string RefreshTokenSecret { get; set; } = string.Empty;
        public int TokenValidityMins { get; set; }
        public int RefreshTokenDays { get; set; }
    }
}
