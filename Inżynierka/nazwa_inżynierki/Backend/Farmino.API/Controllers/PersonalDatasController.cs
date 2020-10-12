using System.Collections.Generic;
using System.Threading.Tasks;
using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
      
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
