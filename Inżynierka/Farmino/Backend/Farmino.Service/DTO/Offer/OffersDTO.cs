using System;
using Farmino.Data.Enums;
using Farmino.Service.DTO.Offer.NestedModels;

namespace Farmino.Service.DTO.Offer
{
    public class OffersDTO
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public FarmerDTO Farmer { get; set; }
        public ProductDTO Product { get; set; }
        public string ImageName { get; set; }
        public Regions Region { get; set; }
        public bool IsActive { get; set; }
    }
}
