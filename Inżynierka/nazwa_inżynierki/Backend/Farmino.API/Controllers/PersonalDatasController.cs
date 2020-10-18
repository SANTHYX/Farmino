using System.Threading.Tasks;
using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonalDatasController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;

        public PersonalDatasController(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetPersonalData command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok("Data has been seted");
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditPersonalData command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok("Data has been edited");
        }
    }
}
