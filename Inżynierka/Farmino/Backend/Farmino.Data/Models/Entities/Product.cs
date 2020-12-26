using Farmino.Data.Exceptions;
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
            throw new NotImplementedException();
        }

        public void SetQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public void SetWeight(Weight weight)
        {
            throw new NotImplementedException();
        }
    }
}
