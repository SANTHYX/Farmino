using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Infrastructure.ORM;

namespace Farmino.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly FarminoDbContext _context;

        public RefreshTokenRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddRefreshTokenAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
        }

        public void EditToken(RefreshToken token)
        {
            _context.RefreshTokens.Update(token);
        }

        public async Task<RefreshToken> GetTokenAsync(string token)
            => await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
