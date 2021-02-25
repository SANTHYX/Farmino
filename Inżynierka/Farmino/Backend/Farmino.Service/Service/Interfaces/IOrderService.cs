using Farmino.Service.DTO;
using Farmino.Service.DTO.DeliverOrder;
using Farmino.Service.DTO.Order;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOrderService : IService
    {
        Task<OrderDTO> GetOrderDetailsAsync(Guid orderId);
        Task<PagedResponseDTO<OrdersDTO>> BrowseOrdersAsync(PagedQuery query, OrderQuery orderQuery);
        Task CancelOrder(Guid orderId);
        Task ReleaseOrder(Guid orderId);
        Task SetupRealisationDate(Guid orderId, DateTime realisationDate);
        Task<PagedResponseDTO<DeliverOrdersDTO>> BrowseDeliverOrdersAsync(PagedQuery query, DateTime date, string userName);
    }
}
