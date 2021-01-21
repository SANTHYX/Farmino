using Farmino.Service.DTO.Customer;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface ICustomerService : IService
    {
        Task<CustomerDTO> GetAsync(string userName);
        Task CreateCustomer(string userName);
    }
}
