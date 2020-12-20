using System.Threading.Tasks;
using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AuthController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("/auth/login")]
        public async Task<IActionResult> Post([FromBody] LoginModel command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok(command.Token);
        }
        /*
        [HttpPost]
        [Route("auth/refresh")]
        public async Task<IActionResult> Post([FromBody])
        {
            await _commandDispatcher.DispatchAsync(command);
        }
        */
    }
}
