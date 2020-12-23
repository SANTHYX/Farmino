using Farmino.Data.Models.Aggregations;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task AddRefreshTokenAsync(RefreshToken token);
        Task<RefreshToken> GetTokenAsync(string token);
        void EditToken(RefreshToken token);
        Task SaveChanges();
    }
}
