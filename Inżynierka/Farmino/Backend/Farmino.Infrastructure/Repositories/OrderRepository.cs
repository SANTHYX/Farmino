using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FarminoDbContext _context;

        public OrderRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void Edit(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Guid offerId)
            => await _context.Orders.Include(x => x.Offer)
                .Include(y => y.Customer).Where(q => q.OfferId == offerId).ToListAsync();

        public async Task<Order> GetAsync(Guid offerId, Guid customerId)
            => await _context.Orders.Include(x => x.Offer)
                .Include(y => y.Customer).ThenInclude(z => z.User).ThenInclude(q => q.Profile)
                .FirstOrDefaultAsync(q => q.OfferId == offerId && q.CustomerId == customerId);


        public void Remove(Order order)
        {
            _context.Remove(order);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
