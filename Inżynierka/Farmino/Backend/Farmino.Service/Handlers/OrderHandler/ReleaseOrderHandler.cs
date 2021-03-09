using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OrderHandler
{
    public class ReleaseOrderHandler : ICommandHandler<ReleaseOrder>
    {
        private readonly IOrderService _orderService;

        public ReleaseOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task HandleAsync(ReleaseOrder command)
        {
            await _orderService.ReleaseOrder(command.OrderId);
        }
    }
}
