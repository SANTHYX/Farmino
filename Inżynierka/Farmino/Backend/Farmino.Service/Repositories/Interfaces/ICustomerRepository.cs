using Farmino.Data.Models.Aggregations;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetAsync(Guid userId);
        Task SaveAsync();
    }
}
