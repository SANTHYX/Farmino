using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.ProductCommands
{
    public class AddProduct : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public double Value { get; set; }
    }
}
