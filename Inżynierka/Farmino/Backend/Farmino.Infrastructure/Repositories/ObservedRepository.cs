using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
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
