using Farmino.Service.Commands.ProductCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ProductHandler
{
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(AddProduct command)
        {
            await _productService.AddProductAsync(command.Name, command.Price, command.Quantity,
                command.Unit, command.Value);
        }
    }
}
