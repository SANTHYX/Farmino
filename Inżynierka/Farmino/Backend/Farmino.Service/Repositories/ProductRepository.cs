using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FarminoDbContext _context;

        public ProductRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void EditAsync(Product product)
        {
            _context.Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task<Product> GetAsync(string name)
            => await _context.Products.FirstOrDefaultAsync(x => x.Name == name);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
