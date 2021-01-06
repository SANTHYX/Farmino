using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly FarminoDbContext _context;

        public OfferRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Offer offer)
        {
            await _context.Offers.AddAsync(offer);
        }

        public void EditAsync(Offer offer)
        {
            _context.Offers.Update(offer);
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
            => await _context.Offers.Include(x => x.Product)
                .Include(y => y.Farmer).ThenInclude(z => z.User).ToListAsync();
            
        public async Task<Offer> GetAsync(Guid id)
            => await _context.Offers.Include(x => x.Product).Include(y => y.Farmer)
                .ThenInclude(z => z.User).ThenInclude(p => p.Profile).FirstOrDefaultAsync(q => q.Id == id);

        public void RemoveAsync(Offer offer)
        {
            _context.Offers.Remove(offer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
