using Farmino.Data.Enums;

namespace Farmino.Service.DTO.Offer.NestedModels
{
    public class ProductDTO
    {
        public decimal BasePrice { get; protected set; }
        public WeightUnits BaseWeightUnit { get; protected set; }
    }
}
