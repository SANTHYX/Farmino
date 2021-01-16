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
        public Guid OfferId { get; protected set; }
        public Offer Offer { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
        public OrderDetails OrderDetails { get; protected set; }
        public double OrderQuantity { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeightUnits OrderUnit { get; protected set; }
        public decimal PriceSummary { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public bool Released { get; protected set; }
        public bool CustomAddress { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer,OrderDetails orderDetails, double orderQuantity, WeightUnits orderUnit,
            decimal priceSummary, bool customAddress)
        {
            Offer = offer;
            Customer = customer;
            OrderDetails = orderDetails;
            SetOrderQuantity(orderQuantity);
            SetOrderUnit(orderUnit);
            SetPriceSummary(priceSummary);
            IsReleased(false);
            IsCustomAddress(customAddress);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetOrderUnit(WeightUnits orderUnit)
        {
            if(!Enum.IsDefined(typeof(WeightUnits), orderUnit))
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid Order Unit");
            }
            if(OrderUnit == orderUnit)
            {
                return;
            }

            OrderUnit = orderUnit;
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
