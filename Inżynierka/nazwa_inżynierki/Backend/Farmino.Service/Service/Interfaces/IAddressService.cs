using Farmino.Service.DTO;
using System.Threading.Tasks;
using Farmino.Service.Service.ServiceResponse;
using System.Collections.Generic;
using System;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAddressService : IService
    {
        Task<ServiceResponse<AddressDTO>> GetAddressAsync(Guid addressId);
        Task<ServiceResponse<IEnumerable<AddressDTO>>> GetAllAddressesAsync();
        Task<ServiceResponse<AddressDTO>> AddAddressAsync(string city, string postalCode,
            string street, int streetNumber);
        Task<ServiceResponse<AddressDTO>> EditAddressAsync(Guid addressId,
            string city, string postalCode, string street, int streetNumber);
    }
}
