using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using Moq;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class ParticipantAuctionTests
    {
        private readonly Mock<ParticipantAuction> participantAuction;

        public ParticipantAuctionTests()
        {
            participantAuction = new Mock<ParticipantAuction>();
        }

        [Fact]
        public void set_proposed_price_should_throw_error_if_value_will_be_lesser_than_zero()
        {
            var testValue = -2;
            var expected = "ProposedPrice should be greather than zero";

            var ex = Assert.Throws<DataExceptions>(() => participantAuction.Object.SetProposedPrice(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_proposed_price_should_throw_error_if_value_will_be_equal_zero()
        {
            var testValue = 0;
            var expected = "ProposedPrice should be greather than zero";

            var ex = Assert.Throws<DataExceptions>(() => participantAuction.Object.SetProposedPrice(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void set_proposed_price_should_pass_if_value_will_be_greater_than_zero()
        {
            var testValue = 5;
            var expected = 5;

            participantAuction.Object.SetProposedPrice(testValue);
            var result = participantAuction.Object.ProposedPrice;

            Assert.Equal(expected, result);
        }
    }
}
