using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class OrderExtensions
    {
        public static async Task<Order> GetIfExistAsync(this IOrderRepository repository, Guid orderId)
        {
            var order = await repository.GetAsync(orderId);

            if (order == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.OrderNotExist,
                    $"Order with not exist");
            }

            return order;
        }
    }
}
