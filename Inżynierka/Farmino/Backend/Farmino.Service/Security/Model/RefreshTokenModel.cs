using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;

namespace Farmino.Service.Security.Model
{
    public class RefreshTokenModel
    {
        public TokenDTO Token { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
