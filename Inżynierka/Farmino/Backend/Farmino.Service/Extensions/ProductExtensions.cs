using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ProductExtensions
    {
        public async static Task<bool> IsProductExistAsync(this IProductRepository repository, Guid id)
            => await repository.GetAsync(id) != null;

        public async static Task<Product> GetIfExistAsync(this IProductRepository repository, Guid id)
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
