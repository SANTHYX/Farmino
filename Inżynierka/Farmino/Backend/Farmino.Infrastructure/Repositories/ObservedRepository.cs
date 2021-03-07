using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class ObservedRepository : IObservedRepository
    {
        private readonly FarminoDbContext _context;

        public ObservedRepository(FarminoDbContext context)
        {
            _context = context;
        }
        public async Task Add(Observed observed)
        {
            await _context.Observeds.AddAsync(observed);
        }

        public IQueryable<Observed> GetAll()
            => _context.Observeds.AsQueryable();

        public async Task<Observed> GetAsync(Guid userId, Guid offerId)
            => await _context.Observeds.FirstOrDefaultAsync(x => x.OfferId == offerId && x.UserId == userId);

        public void Remove(Observed observed)
        {
            _context.Observeds.Remove(observed);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
