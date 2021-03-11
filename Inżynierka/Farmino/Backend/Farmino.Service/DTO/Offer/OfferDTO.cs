using Farmino.Service.DTO.Offer.NestedModels;
using System;

namespace Farmino.Service.DTO.Offer
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double MinQuantity { get; set; }
        public FarmerDTO Farmer { get; set; }
        public ProductDTO Product { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
    }
}
