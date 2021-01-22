using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OrderHandler
{
    public class CancelOrderHandler : ICommandHandler<CancelOrder>
    {
        private readonly IOrderService _orderService;

        public CancelOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task HandleAsync(CancelOrder command)
        {
            await _orderService.CancelOrder(command.OrderId);
        }
    }
}
