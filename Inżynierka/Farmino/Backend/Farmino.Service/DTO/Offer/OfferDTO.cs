using Farmino.Service.DTO.Offer.NestedModels;
using System;

namespace Farmino.Service.DTO.Offer
{
    public class OfferDTO
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public FarmerDTO Farmer { get; protected set; }
        public ProductDTO Product { get; protected set; }
    }
}
