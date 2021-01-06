using Farmino.Data.Models.Aggregations;
using Farmino.Service.Security.Model;

namespace Farmino.Service.Security.Interfaces
{ 
    public interface ITokenManager
    {
        RefreshTokenModel GenerateToken(User user);
    }
}
