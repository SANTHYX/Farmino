using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetAsync(Guid offerId, Guid customerId);
        Task<IEnumerable<Order>> GetAllAsync(Guid offerId);
        Task AddAsync(Order order);
        void Edit(Order order);
        void Remove(Order order);
        Task SaveChanges();
    }
}
