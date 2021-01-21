using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Customer;
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
        private readonly IMapper _mapper;

        public CustomerService(IUserRepository userRepository,
            ICustomerRepository customerRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
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

        public async Task<CustomerDTO> GetAsync(string userName)
        {
            var customer = await _customerRepository.GetAsync(userName);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
