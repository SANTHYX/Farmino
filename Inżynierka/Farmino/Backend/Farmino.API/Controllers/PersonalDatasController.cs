using System.Threading.Tasks;
using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Dispatchers.Interfaces;
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

        [HttpPut]
        [Route("personalDatas/generalData")]
        public async Task<IActionResult> Put([FromBody] EditGeneralData command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok("Data has been edited completly");
        }

        [HttpPut]
        [Route("personalDatas/personalAddress")]
        public async Task<IActionResult> Put([FromBody] EditPersonalAddress command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok("Address has been edited completly");
        }
    }
}
