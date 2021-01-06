namespace Farmino.Service.DTO.Offer.NestedModels
{
    public class ProductDTO
    { 
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public WeightDTO Weight { get; protected set; }
    }
}
