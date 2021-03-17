using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Order;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
            => Ok(await _orderService.GetOrderDetailsAsync(orderId));

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagedQuery paged,[FromQuery]OrderQuery query)
            => Ok(await _orderService.BrowseOrdersAsync(paged, query));

        [Authorize]
        [HttpGet("delivery-orders/{date},{userName}")]
        public async Task<IActionResult> Get([FromQuery] PagedQuery paged, DateTime date, string userName)
            => Ok(await _orderService.BrowseDeliverOrdersAsync(paged, date, userName));

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SetRealisationDate command) 
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been edited");
        }

        [Authorize]
        [HttpPut("cancel")]
        public async Task<IActionResult> Put([FromBody] CancelOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been canceled");
        }

        [Authorize]
        [HttpPut("release")]
        public async Task<IActionResult> Put([FromBody] ReleaseOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been released");
        }

    }
}
