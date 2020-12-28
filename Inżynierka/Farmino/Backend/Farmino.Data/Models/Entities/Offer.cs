using Farmino.Data.Models.Aggregations;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Offer
    {
        public Guid Id { get; protected set; }
        public Guid FarmerId { get; protected set; }
        public Farmer Farmer { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Product Product { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Offer() { }

        public Offer(Farmer farmer, string title, 
            string description, Product product) 
        {
            Id = Guid.NewGuid();
            SetFarmer(farmer);
            SetTitle(title);
            SetDescription(description);
            SetProduct(product);
            CreatedAt = DateTime.Now;
        }

        public void SetFarmer(Farmer farmer)
        {
            throw new NotImplementedException();
        }

        public void SetTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(string description)
        {
            throw new NotImplementedException();
        }

        public void SetProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
