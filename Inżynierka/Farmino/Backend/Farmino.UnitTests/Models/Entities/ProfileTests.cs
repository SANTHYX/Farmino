using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models.Entities
{
    public class ProfileTests
    {
        private readonly Mock<Profile> _personalData;
        private readonly Mock<Address> _address;

        public ProfileTests()
        {
            _personalData = new Mock<Profile>();
            _address = new Mock<Address>();
        }

        [Fact]
        public void FirstName_field_should_throw_exception_when_passing_value_is_empty()
        {
            string expected = "FirstName cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetFirstName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void FirstName_field_should_throw_exception_when_passing_value_is_only_whitespaces()
        {
            string expected = "FirstName cannot be empty";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetFirstName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void FirstName_field_should_have_completly_seted_passing_not_empty_string()
        {
            string expected = "FirstName";
            string testValue = "FirstName";

            _personalData.Object.SetFirstName(testValue);
            var result = _personalData.Object.FirstName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstName_field_should_not_change_value_if_is_same_as_actual_passing_argument()
        {

            string expected = "FirstName";
            string testValue = "FirstName";

            _personalData.Object.SetFirstName("FirstName");
            var before = _personalData.Object.FirstName;
            _personalData.Object.SetFirstName(testValue);
            var result = _personalData.Object.FirstName;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }

        [Fact]
        public void LastName_field_should_throw_exception_when_passing_value_is_empty()
        {
            string expected = "LastName cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetLastName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void LastName_field_should_throw_exception_when_passing_value_is_only_whitespaces()
        {
            string expected = "LastName cannot be empty";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetLastName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void LastName_field_should_have_completly_seted_passing_not_empty_string()
        {
            string expected = "LasttName";
            string testValue = "LasttName";

            _personalData.Object.SetLastName(testValue);
            var result = _personalData.Object.LastName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void LasttName_field_should_not_change_value_if_is_same_as_actual_passing_argument()
        {

            string expected = "LastName";
            string testValue = "LastName";

            _personalData.Object.SetLastName("LastName");
            var before = _personalData.Object.LastName;
            _personalData.Object.SetLastName(testValue);
            var result = _personalData.Object.LastName;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_is_empty_string()
        {
            string expected = "Number is invalid";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_is_only_whitespaces()
        {
            string expected = "Number is invalid";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_have_less_numbers()
        {
            string expected = "Number is too short or too long,number should contain 9 numbers";
            string testValue = "356-241-2";

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_have_more_numbers()
        {
            string expected = "Number is too short or too long,number should contain 9 numbers";
            string testValue = "356-241-2278";

            var result = Assert.Throws<DataExceptions>(() => _personalData.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_not_change_value_if_argument_and_field_have_same_value()
        {
            string expected = "356-241-227";
            string testValue = "356-241-227";
            _personalData.Object.SetPhoneNumber(testValue);
            var before = _personalData.Object.PhoneNumber;
            _personalData.Object.SetPhoneNumber(testValue);
            var result = _personalData.Object.PhoneNumber;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }
    }
}
