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

        protected Order() { }

        public Order(Offer offer, Customer customer,Address address)
        {
            Offer = offer;
            Customer = customer;
            OrderAddress = address;
        }
    }
}
