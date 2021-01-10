using Farmino.Service.DTO.Order.NestedModels;
using System;

namespace Farmino.Service.DTO.Order
{
    public class OrderDTO
    {
        public Guid OfferId { get; set; }
        public CustomerDTO Customer { get; set; }
        public AddressDTO OrderAddress { get; set; }
        public int BoughtQuantity { get; set; }
        public decimal PriceSummary { get; set; }
        public bool Released { get; set; }
    }
}
