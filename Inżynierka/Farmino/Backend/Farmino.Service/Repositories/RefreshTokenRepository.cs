using Farmino.Data.Models.Aggregations;
using Farmino.Service.ORM;
using Microsoft.EntityFrameworkCore;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
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
