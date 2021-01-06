using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
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

        public async Task<Order> GetAsync(Guid offerId, Guid customerId)
            => await _context.Orders
                .FirstOrDefaultAsync(x => x.OfferId == offerId && x.CustomerId == customerId);

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
