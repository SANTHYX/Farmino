using Farmino.Data.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmino.Data.Models.Aggregations
{
    public class Order
    {
        [Key]
        public Guid Id { get; protected set; }
        [Required]
        public Guid OfferId { get; protected set; }
        [ForeignKey("OfferId")]
        public Offer Offer { get; protected set; }
        [Required]
        public Guid CustomerId { get; protected set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; protected set; }

        protected Order() { }

        public Order(Offer offer, Customer customer)
        {
            Id = Guid.NewGuid();
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
