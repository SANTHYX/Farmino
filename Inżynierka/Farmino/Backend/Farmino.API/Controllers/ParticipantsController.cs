using Farmino.Service.Commands.ParticipantCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ParticipantsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateParticipant command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Participant has been created");
        }
    }
}
