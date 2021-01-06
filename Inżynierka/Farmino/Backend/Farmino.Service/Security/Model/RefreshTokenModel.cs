using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO.Token;

namespace Farmino.Service.Security.Model
{
    public class RefreshTokenModel
    {
        public TokenDTO Token { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
