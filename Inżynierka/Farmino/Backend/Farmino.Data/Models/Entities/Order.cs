using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Order
    {
        public Guid OfferId { get; protected set; }
        public Offer Offer { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
        public OrderDetails OrderDetails { get; protected set; }
        public double OrderQuantity { get; protected set; }
        public decimal PriceSummary { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public bool Released { get; protected set; }
        public bool CustomAddress { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer,OrderDetails orderDetails, double orderQuantity,
            decimal priceSummary, bool customAddress)
        {
            Offer = offer;
            Customer = customer;
            OrderDetails = orderDetails;
            SetOrderQuantity(orderQuantity);
            SetPriceSummary(priceSummary);
            IsReleased(false);
            IsCustomAddress(customAddress);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetOrderQuantity(double orderQuantity)
        {
            if (orderQuantity <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidOrderQuantity,
                    "OrderQuantity cannot be less or equal zero");
            }
            if (OrderQuantity == orderQuantity)
            {
                return;
            }

            OrderQuantity = orderQuantity;
            UpdatedAt = DateTime.Now;
        }

        public void SetPriceSummary(decimal priceSummary)
        {
            if (priceSummary <= decimal.Zero)
            {
                throw new DataExceptions(DataErrorCodes.InvalidPriceSummary,
                    "PriceSummary cannot be less or equal zero");
            }
            if (PriceSummary == priceSummary)
            {
                return;
            }

            PriceSummary = priceSummary;
            UpdatedAt = DateTime.Now;
        }

        public void IsReleased(bool released)
        {
            if (Released == released)
            {
                return;
            }

            Released = released;
            UpdatedAt = DateTime.Now;
        }

        public void IsCustomAddress(bool customAddress)
        {
            if (CustomAddress == customAddress)
            {
                return;
            }

            CustomAddress = customAddress;
            UpdatedAt = DateTime.Now;
        }

        public void SetReleaseDate(DateTime date)
        {
            if (date < DateTime.Now)
            {
                throw new DataExceptions(DataErrorCodes.InvalidDate,
                    "Invalid Date");
            }
            if (ReleaseDate == date)
            {
                return;
            }

            ReleaseDate = date;
            UpdatedAt = DateTime.Now;
        }
    }
}
