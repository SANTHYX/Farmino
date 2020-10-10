using Farmino.Service.DTO;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Farmino.Service.Service.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AddressService : IAddressService
    {
        public readonly FarminoDbContext _context;

        public AddressService(FarminoDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<AddressDTO>> AddAddressAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<AddressDTO>> EditAddressAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<AddressDTO>> GetAddressAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ServiceResponse<AddressDTO>>> GetAllAddressesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
