using Farmino.Data.Models.Aggregations;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
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

        public async Task<IEnumerable<Auction>> GetAllAsync()
            => await _context.Auctions.ToListAsync();

        public async Task<Auction> GetAsync(Guid id)
            => await _context.Auctions.Include(x => x.Auctioner)
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
