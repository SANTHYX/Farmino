using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models.Entities
{
    public class ProfileTest
    {
        private readonly Mock<Profile> _profile;

        public ProfileTest()
        {
            _profile = new Mock<Profile>();
        }

        [Fact]
        public void FirstName_field_should_throw_exception_when_passing_value_is_empty()
        {
            string expected = "FirstName cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetFirstName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void FirstName_field_should_throw_exception_when_passing_value_is_only_whitespaces()
        {
            string expected = "FirstName cannot be empty";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetFirstName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void FirstName_field_should_have_completly_seted_passing_not_empty_string()
        {
            string expected = "FirstName";
            string testValue = "FirstName";

            _profile.Object.SetFirstName(testValue);
            var result = _profile.Object.FirstName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstName_field_should_not_change_value_if_is_same_as_actual_passing_argument()
        {

            string expected = "FirstName";
            string testValue = "FirstName";

            _profile.Object.SetFirstName("FirstName");
            var before = _profile.Object.FirstName;
            _profile.Object.SetFirstName(testValue);
            var result = _profile.Object.FirstName;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }

        [Fact]
        public void LastName_field_should_throw_exception_when_passing_value_is_empty()
        {
            string expected = "LastName cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetLastName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void LastName_field_should_throw_exception_when_passing_value_is_only_whitespaces()
        {
            string expected = "LastName cannot be empty";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetLastName(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void LastName_field_should_have_completly_seted_passing_not_empty_string()
        {
            string expected = "LasttName";
            string testValue = "LasttName";

            _profile.Object.SetLastName(testValue);
            var result = _profile.Object.LastName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void LasttName_field_should_not_change_value_if_is_same_as_actual_passing_argument()
        {

            string expected = "LastName";
            string testValue = "LastName";

            _profile.Object.SetLastName("LastName");
            var before = _profile.Object.LastName;
            _profile.Object.SetLastName(testValue);
            var result = _profile.Object.LastName;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_is_empty_string()
        {
            string expected = "Number is invalid";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_is_only_whitespaces()
        {
            string expected = "Number is invalid";
            string testValue = "    ";

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_have_less_numbers()
        {
            string expected = "Number is too short or too long,number should contain 9 numbers";
            string testValue = "356-241-";

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_throw_exception_if_passed_argument_have_more_numbers()
        {
            string expected = "Number is too short or too long,number should contain 9 numbers";
            string testValue = "356-241-2278";

            var result = Assert.Throws<DataExceptions>(() => _profile.Object.SetPhoneNumber(testValue));

            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PhoneNumber_field_should_not_change_value_if_argument_and_field_have_same_value()
        {
            string expected = "356-241-227";
            string testValue = "356-241-227";
            _profile.Object.SetPhoneNumber(testValue);
            var before = _profile.Object.PhoneNumber;
            _profile.Object.SetPhoneNumber(testValue);
            var result = _profile.Object.PhoneNumber;

            Assert.Equal(expected, result);
            Assert.Equal(before, result);
        }
    }
}