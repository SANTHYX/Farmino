using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AddressesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Address has been setted completly");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Address has been edited completly");
        }
    }
}
