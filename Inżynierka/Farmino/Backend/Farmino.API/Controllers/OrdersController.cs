using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Queries.Order;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IOrderService _orderService;

        public OrdersController(ICommandDispatcher commandDispatcher, IOrderService orderService)
        {
            _commandDispatcher = commandDispatcher;
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
            => Ok(await _orderService.GetOrderDetailsAsync(orderId));

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]OrderQuery query)
            => Ok(await _orderService.BrowseOrdersAsync(query));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SetRealisationDate command) 
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been edited");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CancelOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been canceled");
        }
    }
}
