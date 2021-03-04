namespace Farmino.Service.DTO.Order.NestedModels
{
    public class OfferDTO
    {
        public string Title { get; set; }
        public ProductDTO Product { get; set; }
        public FarmerDTO Farmer { get; set; }
    }
}
