using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Moq;
using System;
using Xunit;

namespace Farmino.UnitTests.Models
{
    public class AuctionTests
    {
        private readonly Mock<Auction> auction;

        public AuctionTests()
        {
            auction = new Mock<Auction>();
        }

        [Fact]
        public void SetTitle_should_throw_exception_if_value_will_be_empty()
        {
            var testValue = "";
            var expected = "Title cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetTitle(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetTitle_should_set_value_if_will_be_not_empty_string()
        {
            var testValue = "TestTitle";
            var expected = "TestTitle";

            auction.Object.SetTitle(testValue);
            var actuall = auction.Object.Title;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetTitle_should_return_if_value_will_be_same_as_actuall()
        {
            var testValue = "TestTitle";

            auction.Object.SetTitle(testValue);
            var expected = auction.Object.UpdatedAt;

            auction.Object.SetTitle(testValue);
            var actuall = auction.Object.UpdatedAt;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetDescription_should_throw_exception_if_value_will_be_empty()
        {
            var testValue = "";
            var expected = "Description cannot be empty";

            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetDescription(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetDescription_should_set_value_if_will_be_not_empty_string()
        {
            var testValue = "Test Description, Quick deliver";
            var expected = "Test Description, Quick deliver";

            auction.Object.SetDescription(testValue);
            var actuall = auction.Object.Description;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetDescription_should_return_if_value_will_be_same_as_actuall()
        {
            var testValue = "Test Description, Quick deliver and a bit longer";

            auction.Object.SetDescription(testValue);
            var expected = auction.Object.UpdatedAt;

            auction.Object.SetDescription(testValue);
            var actuall = auction.Object.UpdatedAt;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetStartDate_should_throw_exception_if_date_will_be_older_than_actual_date()
        {
            var testStartValue = DateTime.Now;
            var expected = "StartDate is invalid, should be actual date or future date";


            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetStartDate(testStartValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetStartDate_should_pass_if_date_will_be_later_than_actual_date()
        {
            var testStartValue = DateTime.Now.AddDays(1);
            var expected = testStartValue;


            auction.Object.SetStartDate(testStartValue);
            var actuall = auction.Object.StartDate;
            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetStartDate_should_return_if_date_will_be_same_as_actual_seted_value()
        {
            var testStartValue = DateTime.Now.AddDays(1);

            auction.Object.SetStartDate(testStartValue);
            var expected = auction.Object.UpdatedAt;

            auction.Object.SetStartDate(testStartValue);
            var actuall = auction.Object.UpdatedAt;

            Assert.Equal(expected, actuall);
        }

        [Fact]
        public void SetEndDate_should_throw_error_if_enddate_value_will_be_lesser_than_start_date()
        {
            var startValue = DateTime.Now.AddSeconds(1);
            var endValue = DateTime.Now;
            var expected = "EndDate cannot be lesser than StartDate";

            auction.Object.SetStartDate(startValue);
            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetEndDate(endValue));

            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetEndDate_should_throw_error_if_enddate_value_will_be_equal_start_date()
        {
            var time = DateTime.Now;
            var startValue = time.AddMilliseconds(3);
            var endValue = time.AddMilliseconds(1);
            var expected = "EndDate cannot be lesser than StartDate";

            auction.Object.SetStartDate(startValue);
            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetEndDate(endValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetEndDate_should_pass_if_enddate_value_will_be_greater_than_start_date()
        {
            var time = DateTime.Now;
            var startValue = time.AddMinutes(1);
            var endValue = time.AddMinutes(3);
            var expected = endValue;

            auction.Object.SetStartDate(startValue);
            auction.Object.SetEndDate(endValue);
            var result = auction.Object.EndDate;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetEndDate_should_return_if_enddate_value_will_be_same_as_actual()
        {
            var time = DateTime.Now;
            var startValue = time.AddMinutes(1);
            var endValue = time.AddMinutes(5);

            auction.Object.SetStartDate(startValue);

            auction.Object.SetEndDate(endValue);
            var expected = auction.Object.EndDate;

            auction.Object.SetEndDate(endValue);
            var result = auction.Object.EndDate; 

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetStartingPrice_should_throw_exception_if_value_will_be_lesser_than_zero()
        {
            var testValue = -1;
            var expected = "StartingPrice cannot be less or equal zero";

            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetStartingPrice(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetStartingPrice_should_throw_exception_if_value_will_be_equal_zero()
        {
            var testValue = 0;
            var expected = "StartingPrice cannot be less or equal zero";

            var ex = Assert.Throws<DataExceptions>(() => auction.Object.SetStartingPrice(testValue));
            Assert.Equal(expected, ex.Message);
        }

        [Fact]
        public void SetStartingPrice_should_pass_if_value_will_be_higher_than_zero() 
        {
            var testValue = 10;
            var expected = 10;

            auction.Object.SetStartingPrice(testValue);
            var result = auction.Object.StartingPrice;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetStartingPrice_should_return_if_value_will_be_same_as_actual()
        {
            var testValue = 10;

            auction.Object.SetStartingPrice(testValue);
            var expected = auction.Object.UpdatedAt;

            auction.Object.SetStartingPrice(testValue);
            var result = auction.Object.UpdatedAt;

            Assert.Equal(expected, result);
        }
    }
}
