using Farmino.Service.Commands.OrderCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public OrdersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        /*
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]) 
        {
        }
        */

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CancelOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been canceled");
        }
    }
}
