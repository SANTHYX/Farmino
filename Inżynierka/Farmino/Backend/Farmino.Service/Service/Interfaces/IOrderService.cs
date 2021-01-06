using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOrderService : IService
    {
        Task CancelOrder(Guid offerId, Guid customerId);
        Task EditOrder(Guid offerId, Guid customerId, int quantity);
    }
}
