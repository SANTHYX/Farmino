using Farmino.Data.Models.Value_Objects;
using Moq;
using System;
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

            var result = Assert.Throws<Exception>(() => _address.Object.SetCity(testValue));
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
    }
}
