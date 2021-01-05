using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
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

            if (!await _customerRepository.IsCustomerExist(userName))
            {
                await _customerRepository.AddAsync(new Customer(user));
                await _customerRepository.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.CustomerAlreadyExist,
                   "Customer with this login already exist");
        }
    }
}
