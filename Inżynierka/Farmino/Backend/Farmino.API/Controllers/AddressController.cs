using System.Threading.Tasks;
using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AddressController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Address has been added completly");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Address has been editted completly");
        }
    }
}
