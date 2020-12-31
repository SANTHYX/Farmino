using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface ICustomerService : IService
    {
        Task CreateCustomer(string userName);
    }
}
