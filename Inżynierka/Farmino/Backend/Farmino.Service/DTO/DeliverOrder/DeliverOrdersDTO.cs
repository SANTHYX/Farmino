using Farmino.Service.DTO.DeliverOrder.NestedModels;
using System;

namespace Farmino.Service.DTO.DeliverOrder
{
    public class DeliverOrdersDTO
    {
        public Guid Id { get; set; }
        public OfferDTO Offer { get; set; }
        public OrderDetailsDTO OrderDetails { get; set; }
    }
}
