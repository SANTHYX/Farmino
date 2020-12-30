using Farmino.Data.Models.ValueObjects;
using System;

namespace Farmino.Service.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public WeightDTO Weight { get; set; }
    }
}
