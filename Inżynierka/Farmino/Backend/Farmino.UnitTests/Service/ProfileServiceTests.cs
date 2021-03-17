using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Service;
using Farmino.Service.Extensions;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using System;

namespace Farmino.UnitTests.Service
{
    public class ProfileServiceTests
    {
        private readonly ProfileService _profileService;
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<IProfileRepository> _profileRepository = new Mock<IProfileRepository>();

        public ProfileServiceTests()
        {
            _profileService = new ProfileService(_userRepository.Object, _profileRepository.Object);
        }

        [Fact]
        public async Task CreateProfileAsync_should_pass_if_user_exist_and_no_profile()
        {
            var userName = "Kristof23";
            var password = "sadqw@axc";
            var salt = "salt";
            var email = "email@gmail.com";

            var user = new User(userName, password, salt, email);
            var profile = new Profile("Janek", "Marek", "121554342");
            _userRepository.Setup(x => x.GetAsync(user.UserName)).ReturnsAsync(() => user);
            _profileRepository.Setup(x => x.GetByUserIdAsync(user.Id)).ReturnsAsync(() => null);

            await _profileService.CreateProfileAsync(userName, "Janek", "Marek", "121554342");
            Assert.True(true);
        }

        [Fact]
        public async Task CreateProfileAsync_should_throw_if_user_got_profile()
        {
            var userName = "Kristof23";
            var password = "sadqw@axc";
            var salt = "salt";
            var email = "email@gmail.com";

            var user = new User(userName, password, salt, email);
            _userRepository.Setup(x => x.GetAsync(user.UserName)).ReturnsAsync(() => user);
            _profileRepository.Setup(x => x.GetByUserIdAsync(user.Id))
                .ReturnsAsync(() => new Profile("Janek", "Marek", "121554342"));

            await Assert.ThrowsAsync<ServiceExceptions>(async
                () => await _profileService.CreateProfileAsync(userName, "Janek", "Marek", "121554342"));
        }

        [Fact]
        public async Task EditProfileAsync_should_throw_if_user_is_not_found()
        {
            var userName = "dowolne";
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => null);
            _profileRepository.Setup(x => x.GetByUserIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => new Profile("Janek", "Marek", "121554342"));

            await Assert.ThrowsAsync<ServiceExceptions>(async
                () => await _profileService.EditProfileAsync(userName, "Janek", "Marek", "121554342"));
        }

        [Fact]
        public async Task EditProfileAsync_should_throw_if_profile_is_not_found()
        {
            var userName = "dowolne";
            var user = new User(userName, "adweq", "adwe", "daeq@gmail.com");
            _userRepository.Setup(x => x.GetAsync(userName))
                .ReturnsAsync(() => user);
            _profileRepository.Setup(x => x.GetByUserIdAsync(user.Id)).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<ServiceExceptions>(async
                () => await _profileService.EditProfileAsync(userName, "Janek", "Marek", "121554342"));
        }

        [Fact]
        public async Task EditProfileAsync_should_pass_if_objects_will_be_found()
        {
            var userName = "dowolne";
            var user = new User(userName, "adweq", "adwe", "daeq@gmail.com");
            var profile = new Profile("Jake", "Grey", "124663874");
            _userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(() => user);
            _profileRepository.Setup(x => x.GetByUserIdAsync(user.Id)).ReturnsAsync(() => profile);

            await _profileService.EditProfileAsync(userName, "Janek", "Marek", "121554342");
            Assert.True(true);
        }
    }
}
