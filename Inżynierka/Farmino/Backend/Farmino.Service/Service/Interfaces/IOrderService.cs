using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOrderService : IService
    {
        Task CancelOrder();
        Task EditOrder();
    }
}
