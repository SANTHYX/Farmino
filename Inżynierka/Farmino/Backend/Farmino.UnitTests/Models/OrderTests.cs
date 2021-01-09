using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class OrderTests
    {
        private readonly Mock<Order> order; 

        public OrderTests()
        {
            order = new Mock<Order>();
        }

        [Fact]
        public void SetBoughtQuantity_throws_error_if_value_will_be_lower_than_zero()
        {
            var testValue = -2;
            var expected = "BoughtQuantity cannot be less or equal zero";

            var ex = Assert.Throws<DataExceptions>(() => order.Object.SetBoughtQuantity(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetBoughtQuantity_pass_if_value_will_be_corect ()
        {
            var testValue = 2;
            var expected = 2;

            order.Object.SetBoughtQuantity(testValue);
            var actuall = order.Object.BoughtQuantity;

            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetBoughtQuantity_returns_if_value_will_be_same_as_actuall()
        {
            var testValue = 2;

            order.Object.SetBoughtQuantity(testValue);
            var actuall = order.Object.UpdatedAt;

            order.Object.SetBoughtQuantity(testValue);
            var expected = order.Object.UpdatedAt; 
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetPriceSummary_should_throw_exception_if_value_will_be_lower_than_zero()
        {
            var testValue = -2;
            var expected = "PriceSummary cannot be less or equal zero";

            var ex = Assert.Throws<DataExceptions>(() => order.Object.SetPriceSummary(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetPriceSummary_should_throw_exception_if_value_will_zero()
        {
            var testValue = 0;
            var expected = "PriceSummary cannot be less or equal zero";

            var ex = Assert.Throws<DataExceptions>(() => order.Object.SetPriceSummary(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetPriceSummary_should_pass_if_value_will_be_positive() 
        {
            var testValue = 1;
            var expected = 1;

            order.Object.SetPriceSummary(testValue);
            var result = order.Object.PriceSummary;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetPriceSummary_should_return_if_value_will_be_same_as_actual()
        {
            var testValue = 1;

            order.Object.SetPriceSummary(testValue);
            var expected = order.Object.UpdatedAt;

            order.Object.SetPriceSummary(testValue);
            var result = order.Object.UpdatedAt; 
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsReleased_should_return_if_value_will_be_same_as_actual()
        {
            var testValue = true;

            order.Object.IsReleased(testValue);
            var expected = order.Object.UpdatedAt;

            order.Object.IsReleased(testValue);
            var actuall = order.Object.UpdatedAt;

            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void IsReleased_should_pass_boolean_value()
        {
            var testValue = true;
            var expected = true;

            order.Object.IsReleased(testValue);
            var actuall = order.Object.Released;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void IsCustomAddress_should_return_if_value_will_be_same_as_actual() 
        {
            var testValue = true;

            order.Object.IsCustomAddress(testValue);
            var expected = order.Object.UpdatedAt;

            order.Object.IsCustomAddress(testValue); 
            var actuall = order.Object.UpdatedAt;

            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void IsCustomAddress_should_pass_boolean_value() 
        {
            var testValue = true;
            var expected = true;

            order.Object.IsCustomAddress(testValue);
            var actuall = order.Object.CustomAddress;
            Assert.Equal(expected, actuall);
        }
    }
}
