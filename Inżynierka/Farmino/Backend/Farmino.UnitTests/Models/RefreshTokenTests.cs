using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class RefreshTokenTests
    {
        private readonly Mock<RefreshToken> refreshToken;

        public RefreshTokenTests()
        {
            refreshToken = new Mock<RefreshToken>();
        }

        [Fact]
        public void SetRevoke_should_set_value_if_we_pass_boolean()
        {
            var testValue = true;
            var expected = true;

            refreshToken.Object.SetRevoke(testValue);
            var result = refreshToken.Object.IsRevoked;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetRefreshToken_should_throw_exception_when_passed_value_will_be_empty()
        {
            var testValue = "";
            var expected = "Token cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => refreshToken.Object.SetRefreshToken(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetRefreshToken_should_pass_value_and_set_token_imitation()
        {
            var testValue = "eySADWQ3215412R12343122112321edsafeX.W523rfdsareyw2314tEWGWEFqwerqwTYDSGetyreqw31245`211";
            var expected = "eySADWQ3215412R12343122112321edsafeX.W523rfdsareyw2314tEWGWEFqwerqwTYDSGetyreqw31245`211";

            refreshToken.Object.SetRefreshToken(testValue);
            var result = refreshToken.Object.Token;
            Assert.Equal(expected, result);
        }
    }
}
