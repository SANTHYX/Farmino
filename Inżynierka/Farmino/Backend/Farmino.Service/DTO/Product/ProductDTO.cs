using Farmino.Service.DTO.Product.NestedModels;
using System;

namespace Farmino.Service.DTO.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public WeightDTO Weight { get; set; }
    }
}
