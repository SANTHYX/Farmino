using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IRepository
    {
        Task AddAsync(Product product);
        void EditAsync(Product product);
        Task<Product> GetAsync(string name);
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task SaveChanges();
    }
}
