using Farmino.Data.Enums;

namespace Farmino.Service.DTO.Offer.NestedModels
{
    public class WeightDTO
    {
        public WeightUnits Unit { get; protected set; }
        public double Value { get; protected set; }
    }
}
