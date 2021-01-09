using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class OfferTests
    {
        private readonly Mock<Offer> offer;
      
        public OfferTests()
        {
            offer = new Mock<Offer>();
        }

        [Fact]
        public void set_title_should_throw_error_if_value_will_be_emptY_string_or_whitespaces_only()
        {
            var testValue = "              ";
            var expected = "Title cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => offer.Object.SetTitle(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_title_should_pass_value_if_will_be_valid() 
        {
            var testValue = "super_title";
            var expected = "super_title";

            offer.Object.SetTitle(testValue);
            var result = offer.Object.Title;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_title_should_return_if_value_if_will_be_same_as_before()
        {
            var testValue = "super_title";

            offer.Object.SetTitle(testValue);
            var expected = offer.Object.UpdatedAt;

            offer.Object.SetTitle(testValue);
            var result = offer.Object.UpdatedAt;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_descripton_should_throw_error_if_value_will_be_emptY_string_or_whitespaces_only()
        {
            var testValue = "              ";
            var expected = "Description cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => offer.Object.SetDescription(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_descripton_should_pass_value_if_will_be_valid()
        {
            var testValue = "descriptionxxxd descrytpowe descryption";
            var expected = "descriptionxxxd descrytpowe descryption";

            offer.Object.SetDescription(testValue);
            var result = offer.Object.Description;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void set_descripton_should_return_if_value_if_will_be_same_as_before()
        {
            var testValue = "Super swieże ziemniaki, prosto z pola";

            offer.Object.SetDescription(testValue);
            var expected = offer.Object.UpdatedAt;

            offer.Object.SetDescription(testValue);
            var result = offer.Object.UpdatedAt;
            Assert.Equal(expected, result);
        }
    }
}
