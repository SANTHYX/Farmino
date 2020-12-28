using Farmino.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IProductRepository : IRepository
    {
        Task AddAsync(Product product);
        void EditAsync(Product product);
        Task<Product> GetAsync(string name);
        Task<IEnumerable<Product>> GetAllAsync();
        Task SaveChanges();
    }
}
