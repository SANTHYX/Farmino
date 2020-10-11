using AutoMapper;
using Farmino.Data.Models;
using Farmino.Service.DTO;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Farmino.Service.Service.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly FarminoDbContext _context;
        private readonly IMapper _mapper;

        public AddressService(FarminoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddressDTO>> AddAddressAsync(string city, string postalCode, 
            string street, int streetNumber)
        {
            ServiceResponse<AddressDTO> serviceResponse = new ServiceResponse<AddressDTO>();

            try
            {
                var address = new Address(city, postalCode, street, streetNumber);
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = "Address has been addedd";
            }
            catch (Exception error)
            {
                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = error.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<AddressDTO>> EditAddressAsync(Guid addressId, 
            string city, string postalCode, string street, int streetNumber)
        {
            ServiceResponse<AddressDTO> serviceResponse = new ServiceResponse<AddressDTO>();

            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
                address.SetCity(city);
                address.SetPostalCode(postalCode);
                address.SetStreet(street);
                address.SetStreetNumber(streetNumber);

                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();

                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = "Address has been updated";
            }
            catch(Exception error)
            {
                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = error.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<AddressDTO>> GetAddressAsync(Guid addressId)
        {
            ServiceResponse<AddressDTO> serviceResponse = new ServiceResponse<AddressDTO>();

            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);

            serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
            serviceResponse.Data = _mapper.Map<Address, AddressDTO>(address);
            return serviceResponse;
        }
        public async Task<ServiceResponse<IEnumerable<AddressDTO>>> GetAllAddressesAsync()
        {
            ServiceResponse<IEnumerable<AddressDTO>> serviceResponse = new ServiceResponse<IEnumerable<AddressDTO>>();

            var addresses = await _context.Addresses.ToListAsync();

            serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
            serviceResponse.Data = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressDTO>>(addresses);
            return serviceResponse;
        }  
    }
}
