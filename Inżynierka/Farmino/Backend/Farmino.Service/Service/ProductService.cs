using Farmino.Service.DTO;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ProductService : IProductService
    {

        public Task AddAsync(string name, decimal price, int quantity, int unit, double value)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
