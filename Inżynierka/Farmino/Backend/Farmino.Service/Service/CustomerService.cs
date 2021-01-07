﻿using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUserRepository userRepository,
            ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }
        public async Task CreateCustomer(string userName)
        {
            var user = await _userRepository.GetIfExistAsync(userName);

            if (!await _customerRepository.IsCustomerExistAsync(userName))
            {
                await _customerRepository.AddAsync(new Customer(user));
                await _customerRepository.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.CustomerAlreadyExist,
                   "Customer with this login already exist");
        }
    }
}
