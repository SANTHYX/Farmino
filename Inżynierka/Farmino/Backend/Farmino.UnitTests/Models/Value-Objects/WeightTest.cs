using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using Farmino.Data.Models.ValueObjects;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models.Value_Objects
{
    public class WeightTest
    {
        private readonly Mock<Weight> _weight;

        public  WeightTest()
        {
            _weight = new Mock<Weight>();
        }

        [Fact]
        public void Is_value_throws_error_if_is_lesser_than_0()
        {
            var testValue = -2;
            var expected = "Weight value of product cannot be less or equal zero";

            var task = Assert.Throws<DataExceptions>(() => _weight.Object.SetValue(testValue));
            Assert.Equal(expected, task.Message);
        }

        [Fact]
        public void Is_value_throws_error_if_is_equal_than_0()
        {
            var testValue = 0;
            var expected = "Weight value of product cannot be less or equal zero";

            var task = Assert.Throws<DataExceptions>(() => _weight.Object.SetValue(testValue));
            Assert.Equal(expected, task.Message);
        }

        [Fact]
        public void Is_value_set_if_is_greather_than_0()
        {
            var testValue = 2;
            var expected = 2;

            _weight.Object.SetValue(testValue);
            var actuall = _weight.Object.Value;

            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void Is_weight_unit_throw_error_if_is_out_of_lower_range()
        {
            var testValue = -1;
            var expected = "This unit are not existing in our system";

            var task = Assert.Throws<DataExceptions>(() => _weight.Object.SetUnit(testValue));
            Assert.Equal(expected, task.Message);
        }

        [Fact]
        public void Is_weight_unit_throw_error_if_is_out_of_higher_range()
        {
            var testValue = 5;
            var expected = "This unit are not existing in our system";

            var task = Assert.Throws<DataExceptions>(() => _weight.Object.SetUnit(testValue));
            Assert.Equal(expected, task.Message);
        }

        [Fact]
        public void Is_weight_unit_set_value_if_will_be_zero()
        {
            var testValue = 0;
            var expected = (WeightUnits)0;

            _weight.Object.SetUnit(testValue);
            var actuall = _weight.Object.Unit;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void Is_weight_unit_set_value_if_will_be_predicted_higest_range()
        {
            var testValue = 4;
            var expected = (WeightUnits)4;

            _weight.Object.SetUnit(testValue);
            var actuall = _weight.Object.Unit;
            Assert.Equal(expected, actuall);
        }
    }
}
