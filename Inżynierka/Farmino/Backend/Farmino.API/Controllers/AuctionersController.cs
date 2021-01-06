using Farmino.Service.Commands.AuctionCommands;
using Farmino.Service.Commands.AuctionerCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AuctionersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuctioner command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Auctioner has been created");
        }
    }
}
