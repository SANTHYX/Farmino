using Farmino.Service.DTO;
using System.Threading.Tasks;
using Farmino.Service.Service.ServiceResponse;
using System.Collections.Generic;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAddressService : IService
    {
        Task<ServiceResponse<AddressDTO>> GetAddressAsync();
        Task<IEnumerable<ServiceResponse<AddressDTO>>> GetAllAddressesAsync();
        Task<ServiceResponse<AddressDTO>> AddAddressAsync();
        Task<ServiceResponse<AddressDTO>> EditAddressAsync();
    }
}
