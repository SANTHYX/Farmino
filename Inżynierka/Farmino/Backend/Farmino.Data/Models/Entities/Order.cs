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
        public Address OrderAddress { get; protected set; }
        public int BoughtQuantity { get; protected set; }
        public decimal PriceSummary { get; protected set; }
        public bool Released { get; protected set; }
        public bool CustomAddress { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer,Address address, int boughtQuantity,
            decimal priceSummary, bool customAddress)
        {
            Offer = offer;
            Customer = customer;
            OrderAddress = address;
            SetBoughtQuantity(boughtQuantity);
            SetPriceSummary(priceSummary);
            IsReleased(false);
            IsCustomAddress(customAddress);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetBoughtQuantity(int boughtQuantity)
        {
            if (boughtQuantity <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidBoughtQuantity,
                    "BoughtQuantity cannot be less or equal zero");
            }
            if (BoughtQuantity == boughtQuantity)
            {
                return;
            }

            BoughtQuantity = boughtQuantity;
            UpdatedAt = DateTime.Now;
        }

        public void SetPriceSummary(decimal priceSummary)
        {
            if (priceSummary <= decimal.Zero)
            {
                throw new DataExceptions(DataErrorCodes.InvalidBoughtQuantity,
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

        private void IsCustomAddress(bool customAddress)
        {
            if (CustomAddress == customAddress)
            {
                return;
            }

            CustomAddress = customAddress;
            UpdatedAt = DateTime.Now;
        }
    }
}
