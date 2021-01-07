using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class UserTests
    {
        private readonly Mock<User> user;

        public UserTests()
        {
            user = new Mock<User>();
        }

        [Fact]
        public void set_userName_should_throw_error_when_value_will_be_empty()
        {
            var testValue = "   ";
            var expected = "Name is invalid";

            var ex = Assert.Throws<DataExceptions>(() => user.Object.SetUserName(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_userName_should_pass_when_value_will_be_string()
        {
            var testValue = "HeyX";
            var expected = "HeyX";

            user.Object.SetUserName(testValue);
            var result = user.Object.UserName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_userName_should_return_when_value_will_be_same_with_one_update_time()
        {
            var testValue = "HeyX";

            user.Object.SetUserName(testValue);
            var expected = user.Object.UpdatedAt;

            user.Object.SetUserName(testValue);
            var result = user.Object.UpdatedAt;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_password_should_throw_error_when_value_will_be_empty()
        {
            var testValue = "   ";
            var expected = "Password is invalid";

            var ex = Assert.Throws<DataExceptions>(() => user.Object.SetPassword(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_password_should_pass_when_value_will_be_string()
        {
            var testValue = "seCret_password";
            var expected = "seCret_password";

            user.Object.SetPassword(testValue);
            var result = user.Object.Password;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_password_should_return_when_value_will_be_same_with_one_update_time()
        {
            var testValue = "SupperSecretPass";

            user.Object.SetPassword(testValue);
            var expected = user.Object.UpdatedAt;

            user.Object.SetPassword(testValue);
            var result = user.Object.UpdatedAt;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_salt_should_throw_error_when_value_will_be_empty()
        {
            var testValue = "   ";
            var expected = "Salt is invalid";

            var ex = Assert.Throws<DataExceptions>(() => user.Object.SetSalt(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_salt_should_pass_when_value_will_be_string()
        {
            var testValue = "wqeqwfsaseqweqwtrqwt233421rfsafzxveqwer42";
            var expected = "wqeqwfsaseqweqwtrqwt233421rfsafzxveqwer42";

            user.Object.SetSalt(testValue);
            var result = user.Object.Salt;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_salt_should_return_when_value_will_be_same_with_one_update_time()
        {
            var testValue = "wqeqwfsaseqweqwtrqwt233421rfs3123vxhftwerqewrqweqafzxveqwer42";

            user.Object.SetSalt(testValue);
            var expected = user.Object.UpdatedAt;

            user.Object.SetSalt(testValue);
            var result = user.Object.UpdatedAt;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_emial_should_throw_error_when_value_will_be_empty()
        {
            var testValue = "   ";
            var expected = "Email cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => user.Object.SetEmail(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_email_should_throw_error_when_value_will_be_invalid_email_structure()
        {
            var testValue = "wqeqwfsa.com";
            var expected = "Invalid Email";

            var ex = Assert.Throws<DataExceptions>(() => user.Object.SetEmail(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_email_should_passr_when_value_will_be_valid_email_structure()
        {
            var testValue = "wqeqwfsa@gmail.com";
            var expected = "wqeqwfsa@gmail.com";

            user.Object.SetEmail(testValue);
            var result = user.Object.Email;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_email_should_return_when_value_will_be_same_with_one_update_time()
        {
            var testValue = "wqeqwfsaseq@gmail.com";

            user.Object.SetEmail(testValue);
            var expected = user.Object.UpdatedAt;

            user.Object.SetEmail(testValue);
            var result = user.Object.UpdatedAt;

            Assert.Equal(expected, result);
        }
    }
}
