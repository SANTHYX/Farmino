using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly FarminoDbContext _context;
        public FarmerRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _context.Farmers.AddAsync(farmer);
        }

        public async Task<Farmer> GetAsync(string userName)
            => await _context.Farmers.Include(x => x.User).Include(x => x.Offers)
            .FirstOrDefaultAsync(x => x.User.UserName == userName);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
