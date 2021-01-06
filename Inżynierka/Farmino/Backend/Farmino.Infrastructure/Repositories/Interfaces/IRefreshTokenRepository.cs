using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task AddRefreshTokenAsync(RefreshToken token);
        Task<RefreshToken> GetTokenAsync(string token);
        void EditToken(RefreshToken token);
        Task SaveChanges();
    }
}
