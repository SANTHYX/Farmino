using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Service;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Farmino.UnitTests.Service
{
    public class FarmerServiceTests
    {

        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<IFarmerRepository> _farmerRepository = new Mock<IFarmerRepository>();
        private readonly FarmerService _farmerService; 

        public FarmerServiceTests()
        {
            _farmerService = new FarmerService(_userRepository.Object, _farmerRepository.Object);
        }

        [Fact]
        public async Task CreateCustomer_is_throw_error_when_user_not_exists()
        {
            var userName = "Janek21";
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _farmerRepository.Setup(x => x.AddAsync(null));
            _farmerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);

            await Assert.ThrowsAnyAsync<ServiceExceptions>(async () => await _farmerService.CreateFarmer(userName));
        }

        [Fact]
        public async Task CreateCustomer_is_pass_if_user_exist_and_customer_dont_exists()
        {
            var userName = "Janek21";
            var user = new User(userName, "passowrd", "saltsaltsalt", "user@gmail.com");
            var farmer = new Farmer(user);
            _farmerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _farmerRepository.Setup(x => x.AddAsync(farmer));
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => user);

            await _farmerService.CreateFarmer(userName);
            Assert.True(true);
        }

        [Fact]
        public async Task CreateCustomer_is_throw_error_when_customer_exists()
        {
            var userName = "Janek21";
            var user = new User(userName, "passowrd", "saltsaltsalt", "user@gmail.com");
            var farmer = new Farmer(user);
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => user);
            _farmerRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => farmer);

            await Assert.ThrowsAsync<ServiceExceptions>(async () => await _farmerService.CreateFarmer(userName));
        }
    }
}
