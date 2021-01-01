using System;

namespace Farmino.Service.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string Refresh { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
