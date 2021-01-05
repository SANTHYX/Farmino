using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations 
{
    public class Offer
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Guid FarmerId { get; protected set; }
        public Farmer Farmer { get; protected set; }
        public Guid ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Order> Orders { get; protected set; }

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
            Farmer = farmer;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Title cannot be empty");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description cannot be empty");
            }
            if (Description == description)
            {
                return;
            }

            Description = description;
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }
    }
}
