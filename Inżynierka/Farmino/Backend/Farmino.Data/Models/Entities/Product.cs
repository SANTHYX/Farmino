using Farmino.Data.Models.ValueObjects;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public decimal Price { get; protected set; }
        public Weight Weight { get; protected set; }
    }
}
