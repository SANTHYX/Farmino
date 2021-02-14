using Farmino.Service.DTO.DeliverOrder;
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
        Task ReleaseOrder(Guid orderId);
        Task SetupRealisationDate(Guid orderId, DateTime realisationDate);
        Task<IEnumerable<DeliverOrdersDTO>> BrowseDeliverOrdersAsync(DateTime date, string userName);
    }
}
