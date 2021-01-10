using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.OfferCommands.NestedModel
{
    public class WeightModel : ICommand
    {
        public int Unit { get; set; }
        public double Value { get; set; }
    }
}
