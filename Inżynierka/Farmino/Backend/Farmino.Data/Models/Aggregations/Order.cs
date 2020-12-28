using Farmino.Data.Models.Entities;
using System;

namespace Farmino.Data.Models.Aggregations
{
    public class Order
    {
        public Guid OfferId { get; protected set; }
        public Offer Offer { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer)
        {
            SetOffer(offer);
            SetCustomer(customer);
        }

        public void SetOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public void SetCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
