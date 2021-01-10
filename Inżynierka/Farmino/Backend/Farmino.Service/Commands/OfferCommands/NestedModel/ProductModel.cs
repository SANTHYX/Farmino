using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.OfferCommands.NestedModel
{
    public class ProductModel: ICommand
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public WeightModel Weight { get; set; }
    }
}
