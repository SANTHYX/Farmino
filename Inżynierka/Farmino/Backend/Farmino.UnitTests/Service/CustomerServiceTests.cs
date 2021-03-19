using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Farmino.UnitTests.Service
{
    public class CustomerServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<ICustomerRepository> _customerRepository = new Mock<ICustomerRepository>();
        private readonly Mock<IMapper> _maper = new Mock<IMapper>();
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerService = new CustomerService(_userRepository.Object, _customerRepository.Object, _maper.Object);
        }

        [Fact]
        public async Task CreateCustomer_is_throw_error_when_user_not_exists()
        {
            var userName = "Janek21";
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _customerRepository.Setup(x => x.AddAsync(null));
            _customerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);

            await Assert.ThrowsAnyAsync<ServiceExceptions>(async () => await _customerService.CreateCustomer(userName));
        }

        [Fact]
        public async Task CreateCustomer_is_pass_if_user_exist_and_customer_dont_exists()
        { 
            var userName = "Janek21";
            var user = new User(userName, "passowrd", "saltsaltsalt", "user@gmail.com");
            var customer = new Customer(user);
            _customerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _customerRepository.Setup(x => x.AddAsync(customer));
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => user);

            await _customerService.CreateCustomer(userName);
            Assert.True(true);
        }

        [Fact]
        public async Task CreateCustomer_is_throw_error_when_customer_exists()
        {
            var userName = "Janek21";
            var user = new User(userName, "passowrd", "saltsaltsalt", "user@gmail.com");
            var customer = new Customer(user);
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => user);
            _customerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => customer);

            await Assert.ThrowsAsync<ServiceExceptions>(async () => await _customerService.CreateCustomer(userName));
        }
    }
}
