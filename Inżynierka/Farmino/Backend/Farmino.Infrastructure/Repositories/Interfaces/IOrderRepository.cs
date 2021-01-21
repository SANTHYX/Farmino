using Farmino.Data.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetAsync(Guid offerId, Guid customerId);
        IQueryable<Order> GetAllAsync();
        Task AddAsync(Order order);
        void Edit(Order order);
        void Remove(Order order);
        Task SaveChanges();
    }
}
