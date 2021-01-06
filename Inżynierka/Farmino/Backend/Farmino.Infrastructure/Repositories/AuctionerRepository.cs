using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class AuctionerRepository : IAuctionerRepository
    {
        private readonly FarminoDbContext _context;

        public AuctionerRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Auctioner auctioner)
        {
            await _context.Auctioners.AddAsync(auctioner);
        }

        public async Task<Auctioner> GetAsync(string userName)
            => await _context.Auctioners.Include(x => x.User)
                .Include(y => y.Auctions).FirstOrDefaultAsync(z => z.User.UserName == userName);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
