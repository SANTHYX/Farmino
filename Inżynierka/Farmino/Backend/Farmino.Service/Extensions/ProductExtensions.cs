using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ProductExtensions
    {
        public async static Task<bool> IsProductExist(this IProductRepository repository, Guid id)
            => await repository.GetAsync(id) != null;

        public async static Task<Product> GetIfExist(this IProductRepository repository, Guid id)
        {
            var product = await repository.GetAsync(id);

            if (product == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ProductNoExist,
                    $"Product with id {id} not exist");
            }

            return product;
        }
    }
}
