using System.Threading.Tasks;
using Farmino.Service.Commands.ProfileCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ProfilesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetProfil command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Profil has been setted");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProfile command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Profile has been edited");
        }
    }
}
