using Farmino.Data.Enums;
using Farmino.Service.DTO.Order.NestedModels;
using System;

namespace Farmino.Service.DTO.Order
{
    public class OrderDTO
    {
        public Guid OfferId { get; set; }
        public OrderDetailsDTO OrderDetails { get; set; }
        public double OrderQuantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal PriceSummary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Released { get; set; }
    }
}
