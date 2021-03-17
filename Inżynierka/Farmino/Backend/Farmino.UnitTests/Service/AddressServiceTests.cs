using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Farmino.UnitTests.Service
{
    public class AddressServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<IProfileRepository> _profileRepository = new Mock<IProfileRepository>();
        private AddressService _addressService;

        public AddressServiceTests()
        {
            _addressService = new AddressService(_userRepository.Object, _profileRepository.Object);
        }

        [Fact]
        public async Task SetAddressAsync_should_throw_when_user_object_not_found()
        {
            var userName = "Barnaba21";
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _profileRepository.Setup(x => x.GetByUserIdAsync(Guid.Empty))
                .ReturnsAsync(() => new Profile("Jack", "Krist", "216634722"));

            await Assert.ThrowsAsync<ServiceExceptions>(async 
                () => await _addressService.SetAddressAsync(userName, "Białystok",
                "Szkolna", "24-111", "2B", new Data.Models.ValueObjects.Node(Double.MaxValue, Double.MaxValue)));
        }

        [Fact]
        public async Task SetAddressAsync_should_throw_when_address_not_empty()
        {
            var userName = "Barnaba21";
            var testProfile = new Profile("Jack", "Krist", "216634722");
            testProfile.SetAddress(Address.Create("Białystok", "Szkolna", "24-111", "2B",
                new Data.Models.ValueObjects.Node(Double.MaxValue, Double.MaxValue)));

            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _profileRepository.Setup(x => x.GetByUserIdAsync(Guid.Empty))
                .ReturnsAsync(() => new Profile("Jack", "Krist", "216634722"));

            await Assert.ThrowsAsync<ServiceExceptions>(async
                () => await _addressService.SetAddressAsync(userName, "Dowolne",
                "Dowolne", "24-111", "2B", new Data.Models.ValueObjects.Node(Double.MaxValue, Double.MaxValue)));
        }

        [Fact]
        public async Task SetAddressAsync_should_throw_when_profile_empty()
        {
            var userName = "Barnaba21";

            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _profileRepository.Setup(x => x.GetByUserIdAsync(Guid.Empty)).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<ServiceExceptions>(async
                () => await _addressService.SetAddressAsync(userName, "Dowolne",
                "Dowolne", "24-111", "2B", new Data.Models.ValueObjects.Node(Double.MaxValue, Double.MaxValue)));
        }

    }
}
