using Farmino.Service.DTO.Order;
using Farmino.Service.Queries.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOrderService : IService
    {
        Task<OrderDTO> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<OrdersDTO>> BrowseOrdersAsync(OrderQuery orderQuery);
        Task CancelOrder(Guid orderId);
        Task SetupRealisationDate(Guid orderId, DateTime realisationDate); 
    }
}
