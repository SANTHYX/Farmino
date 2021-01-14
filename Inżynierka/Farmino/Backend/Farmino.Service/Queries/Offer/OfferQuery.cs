namespace Farmino.Service.Queries.Offer
{
    public class OfferQuery
    {
        #nullable enable
        public string? Region { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        #nullable disable
    }
}
