using Farmino.Service.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ProductExtensions
    {
        public async static Task<bool> IsProductExist(this IProductRepository productRepository, Guid id)
            => await productRepository.GetAsync(id) != null;
    }
}
