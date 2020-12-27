using Farmino.Data.Models.Aggregations;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FarminoDbContext _context;

        public CustomerRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.AddAsync(customer);
        }

        public async Task<Customer> GetAsync(Guid id)
            => await _context.Customers.FirstOrDefaultAsync(x => x.UserId == id);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
