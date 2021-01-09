using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Farmino.UnitTests.Service
{
    public class UserServiceTests
    {
        private readonly UserService userService;
        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly Mock<IEncryption> encryption = new Mock<IEncryption>();

        public UserServiceTests()
        {
            userService = new UserService(mapper.Object, userRepository.Object, encryption.Object);
        }

        [Fact]
        public async Task GetUserAsync_should_return_expected_user()
        {
            var userName = "Kristof23";
            var password = "sadqw@axc";
            var salt = "salt";
            var email = "email@gmail.com";

            var user = new User(userName, password, salt, email);
            userRepository.Setup(x => x.GetAsync(userName)).ReturnsAsync(user);

            var userResponse = await userService.GetUserAsync(userName);

            Assert.Equal(userName, user.UserName);
        }

        [Fact]
        public async Task GetUserAsync_should_return_null_if_user_dont_exist()
        {
            userRepository.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var userResponse = await userService.GetUserAsync("testUserName");

            Assert.Null(userResponse);
        }

        [Fact]
        public async Task GetAllUsersAsync_should_return_collection_of_users_if_exist()
        {
            IEnumerable<User> userCollection = new[]
            {
                new User("jadzia32", "sdw2111!", "salt", "sadsdw@gmail.com"),
                new User("zbigniew32", "sxzdw2sda!", "salt", "sad22w@gmail.com")
            };

            userRepository.Setup(x => x.BrowseAsync()).ReturnsAsync(userCollection);

            var users = await userService.GetAllUsersAsync();

            Assert.NotNull(userCollection);
            Assert.NotEmpty(userCollection);
            Assert.Equal("jadzia32", userCollection.First().UserName);
        }

        [Fact]
        public async Task GetAllUsersAsync_should_return_empty_if_any_user_not_exist()
        {
            IEnumerable<User> user = Enumerable.Empty<User>();

            userRepository.Setup(x => x.BrowseAsync()).ReturnsAsync(() => user);

            var users = await userService.GetAllUsersAsync();

            Assert.NotNull(users);
            Assert.Empty(users);
        }

        [Fact]
        public async Task EditAsync_should_change_user_object()
        {
            var userTest = new User("userTest", "password1@", "salt", "email@gmail.com");
            var editUserName = "EditUserName";
            var editPassword = "passwordEdited";
            var editEmail = "editedmail@gmail.com";

            userRepository.Setup(x => x.GetAsync(userTest.UserName)).ReturnsAsync(userTest);
            userRepository.Setup(x => x.EditAsync(userTest));
            encryption.Setup(x => x.GenerateSalt(editPassword)).Returns(()=>"editSalt");
            encryption.Setup(x => x.GenerateHash(editPassword, "editSalt")).Returns(()=> editPassword);

            await userService.EditAsync(userTest.UserName, editUserName, editPassword, editEmail);

            Assert.Equal(userTest.UserName, editUserName);
            Assert.Equal(userTest.Password, editPassword);
            Assert.Equal("salt", userTest.Salt);
            Assert.Equal(userTest.Email, editEmail);
        }

        [Fact]
        public async Task EditAsync_should_throw_exception_where_user_dont_exist()
        {
            var editUserName = "EditUserName";
            var editPassword = "passwordEdited";
            var editEmail = "editedmail@gmail.com";
            var userName = "testUser";

            userRepository.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);
            encryption.Setup(x => x.GenerateSalt(editPassword)).Returns(() => "editSalt");
            encryption.Setup(x => x.GenerateHash(editPassword, "editSalt")).Returns(() => editPassword);

            await Assert.ThrowsAsync<ServiceExceptions>(async 
                () => await userService.EditAsync(userName, editUserName, editPassword, editEmail));
        }
    }
}