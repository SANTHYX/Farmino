using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;
using System;
using System.Text.Json.Serialization;

namespace Farmino.Data.Models.Entities
{
    public class Order
    {
        public Guid Id { get; protected set; }
        public Guid OfferId { get; protected set; }
        public Offer Offer { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
        public OrderDetails OrderDetails { get; protected set; }
        public double OrderQuantity { get; protected set; }
        public decimal PriceSummary { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public bool CustomAddress { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer,OrderDetails orderDetails, double orderQuantity,
            decimal priceSummary, bool customAddress)
        {
            Id = Guid.NewGuid();
            Offer = offer;
            Customer = customer;
            OrderDetails = orderDetails;
            SetOrderStatus(OrderStatus.Oczekujaca);
            SetOrderQuantity(orderQuantity);
            SetPriceSummary(priceSummary);
            IsCustomAddress(customAddress);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetOrderStatus(OrderStatus status)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), status))
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid order status");
            }

            OrderStatus = status;
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
            if (date < DateTime.Now.Date)
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
