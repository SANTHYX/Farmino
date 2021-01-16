using Farmino.Data.Enums;
using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.OfferCommands.NestedModel
{
    public class ProductCommand : ICommand
    {
        public decimal BasePrice { get; set; }
        public WeightUnits BaseWeightUnit { get; set; }
    }
}
