using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly FarminoDbContext _context;

        public AuctionRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
        }

        public IQueryable<Auction> GetAllAsync()
            => _context.Auctions.AsQueryable();

        public async Task<Auction> GetAsync(Guid id)
            => await _context.Auctions.Include(x => x.Auctioner).ThenInclude(y=>y.User)
                .Include(z => z.Participants).FirstOrDefaultAsync(x => x.Id == id);

        public void Remove(Auction auction)
        {
            _context.Auctions.Remove(auction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
