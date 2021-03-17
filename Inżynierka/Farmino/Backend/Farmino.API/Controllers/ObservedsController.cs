using Farmino.Service.Commands.ObservedCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObservedsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IObservedService _observedService;

        public ObservedsController(ICommandDispatcher commandDispatcher, IObservedService observedService) 
        {
            _commandDispatcher = commandDispatcher;
            _observedService = observedService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObserveOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been created");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UnobserveOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been removed");
        }
    }
}

