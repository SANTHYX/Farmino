using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public Weight Weight { get; protected set; }
        public Offer Offer { get; protected set; }

        protected Product() { }

        public Product(string name, decimal price, int quantity, Weight weight)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
            SetWeight(weight);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductName, 
                    "Name of product cannot be empty");
            }
            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductPrice,
                    "Price cannot be less or equal zero");
            }
            if (Price == price)
            {
                return;
            }

            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductQuantity,
                    "Product quantity cannot be less than zero");
            }
            if (Quantity == quantity)
            {
                return;
            }

            Quantity = quantity;
        }

        public void SetWeight(Weight weight)
        {
            Weight = weight;
        }
    }
}
