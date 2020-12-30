using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IProductService : IService
    {
        Task AddProductAsync(string name, decimal price, int quantity,
            int unit, double value);
        Task<ProductDTO> GetAsync(Guid id);
    }
}
