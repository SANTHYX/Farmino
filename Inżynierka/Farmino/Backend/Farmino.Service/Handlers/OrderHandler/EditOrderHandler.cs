using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OrderHandler
{
    public class EditOrderHandler : ICommandHandler<SetRealisationDate>
    {
        private readonly IOrderService _orderService;

        public EditOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task HandleAsync(SetRealisationDate command)
        {
            await _orderService.SetupRealisationDate(command.OrderId, command.RealisationDate);
        }
    }
}
