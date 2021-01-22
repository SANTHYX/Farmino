using Farmino.Data.Enums;
using Farmino.Service.DTO.Order.NestedModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Farmino.Service.DTO.Order
{
    public class OrdersDTO
    {
        public Guid Id { get; set; } 
        public Guid OfferId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal PriceSummary { get; set; }
        public double OrderQuantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime ReleaseDate { get; set; }
        public OfferDTO Offer { get; set; }
    }
}
