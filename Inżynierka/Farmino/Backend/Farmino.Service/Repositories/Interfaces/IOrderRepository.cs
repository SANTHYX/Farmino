using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetAsync(Guid offerId, Guid customerId); 
        Task AddAsync(Order order);
        void Edit(Order order);
        void Remove(Order order);
        Task SaveChanges();
    }
}
