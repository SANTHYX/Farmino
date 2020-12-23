using Farmino.Data.Exceptions;
using Farmino.Data.Models.ValueObjects;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models.Value_Objects
{
    public class AddressTest
    {

        // Mock wykonany ze względu chronionego kontruktora bezagrumentowego potrzebnego do wykonania migrajci przez EF core 
        private readonly Mock<Address> _address;

        public AddressTest()
        {
            _address = new Mock<Address>();
        }

        [Fact]
        public void City_field_should_throw_exception_if_passing_value_will_be_empty()
        {
            string expected = "City cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _address.Object.SetCity(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void City_field_should_be_seted_if_passing_value_is_not_empty()
        { 
            string expected = "testCity";
            string testValue = "testCity";

            _address.Object.SetCity(testValue);
            var result = _address.Object.City;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void City_field_hasnt_change_if_passing_value_will_be_actual_value_of_field()
        {
            string expected = "testCity1";
            string testValue = "testCity1";

            _address.Object.SetCity("testCity1");
            var before = _address.Object.City;
            _address.Object.SetCity(testValue);
            var result = _address.Object.City;

            Assert.Equal(expected, result);
            Assert.Same(before, result);
        }

        [Fact]
        public void Street_field_should_throw_exception_if_passing_value_will_be_empty()
        {
            string expected = "Street cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _address.Object.SetStreet(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void Street_field_should_be_seted_if_passing_value_is_not_empty()
        {
            string expected = "testStreet";
            string testValue = "testStreet";

            _address.Object.SetStreet(testValue);
            var result = _address.Object.Street;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Street_field_hasnt_change_if_passing_value_will_be_actual_value_of_field()
        {
            string expected = "testStreet1";
            string testValue = "testStreet1";

            _address.Object.SetStreet("testStreet1");
            var before = _address.Object.Street;
            _address.Object.SetStreet(testValue);
            var result = _address.Object.Street;

            Assert.Equal(expected, result);
            Assert.Same(before, result);
        }

        [Fact]
        public void PostalCode_field_should_throw_exception_if_passing_value_will_be_empty()
        {
            string expected = "PostalCode cannot be empty";
            string testValue = string.Empty;

            var result = Assert.Throws<DataExceptions>(() => _address.Object.SetPostalCode(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PostalCode_field_should_throw_exception_if_passing_value_will_be_include_whitespace_only()
        {
            string expected = "PostalCode cannot be empty";
            string testValue = "  ";

            var result = Assert.Throws<DataExceptions>(() => _address.Object.SetPostalCode(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void PostalCode_field_should_be_seted_if_passing_value_is_not_empty()
        {
            string expected = "testPostalCode";
            string testValue = "testPostalCode";

            _address.Object.SetPostalCode(testValue);
            var result = _address.Object.PostalCode;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PostalCode_field_hasnt_change_if_passing_value_will_be_actual_value_of_field()
        {
            string expected = "testPostalCode";
            string testValue = "testPostalCode";

            _address.Object.SetPostalCode("testPostalCode");
            var before = _address.Object.PostalCode;
            _address.Object.SetPostalCode(testValue);
            var result = _address.Object.PostalCode;

            Assert.Equal(expected, result);
            Assert.Same(before, result);
        }

        [Fact]
        public void HouseNumber_filed_should_throw_exception_if_value_will_equal_zero()
        {
            string expected = "HouseNumber is invalid";
            int testValue = 0;

            var result = Assert.Throws<DataExceptions>(()=>_address.Object.SetHouseNumber(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void HouseNumber_filed_should_throw_exception_if_value_will_be_less_than_zero()
        {
            string expected = "HouseNumber is invalid";
            int testValue = -1;

            var result = Assert.Throws<DataExceptions>(() => _address.Object.SetHouseNumber(testValue));
            Assert.Equal(expected, result.Message);
        }

        [Fact]
        public void HouseNumber_field_hasnt_change_if_passing_value_will_be_actual_value_of_field()
        {
            int expected = 2;
            int testValue = 2;

            _address.Object.SetHouseNumber(2);
            var before = _address.Object.HouseNumber;
            _address.Object.SetHouseNumber(testValue);
            var result = _address.Object.HouseNumber;

            Assert.Equal(expected, result);
        }
    }
}
