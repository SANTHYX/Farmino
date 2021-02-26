using Microsoft.AspNetCore.Mvc;

namespace Farmino.Service.Queries.Offer
{
    public class OfferQuery
    {
        #nullable enable
        [FromQuery(Name = "Phrase")]
        public string? Phrase { get; set; }
        [FromQuery(Name = "PriceFrom")]
        public decimal? PriceFrom { get; set; }
        [FromQuery(Name = "PriceTo")]
        public decimal? PriceTo { get; set; }
        [FromQuery(Name = "FarmerName")]
        public string? FarmerName { get; set; }
        [FromQuery(Name = "City")]
        public string? City { get; set; }
        #nullable disable
    }
}
