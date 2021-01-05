using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            await _context.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetAsync(string login)
            => await _context.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.User.UserName == login);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
