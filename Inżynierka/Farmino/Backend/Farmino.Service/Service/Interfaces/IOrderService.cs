using Farmino.Service.DTO.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOrderService : IService
    {
        Task<OrderDTO> GetOrderDetailsAsync(Guid offerId, Guid customerId);
        Task<IEnumerable<OrdersDTO>> BrowseOrdersAsync(Guid offerId);
        Task CancelOrder(Guid offerId, Guid customerId);
        Task EditOrder(Guid offerId, Guid customerId, int quantity);
    }
}
