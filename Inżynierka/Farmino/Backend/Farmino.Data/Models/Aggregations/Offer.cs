using Farmino.Data.Exceptions;
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
        public DateTime UpdatedAt { get; protected set; } 
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
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DataExceptions(DataErrorCodes.InvalidTitle,
                    "Title cannot be empty");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
            UpdatedAt = DateTime.Now;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DataExceptions(DataErrorCodes.InvalidDescription, 
                    "Description cannot be empty");
            }
            if (Description == description)
            {
                return;
            }

            Description = description;
            UpdatedAt = DateTime.Now;
        }

        public void SetProduct(Product product)
        {
            Product = product;
            UpdatedAt = DateTime.Now;
        }

        public void SetFarmer(Farmer farmer)
        {
            Farmer = farmer;
            UpdatedAt = DateTime.Now;
        }
    }
}
