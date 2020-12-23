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

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] LoginModel command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok(command.Token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("User has been created");
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Post([FromBody] RefreshToken command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok(command.TokenResponse);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Post([FromBody] RevokeToken command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Token has been revoked");
        }
    }
}
