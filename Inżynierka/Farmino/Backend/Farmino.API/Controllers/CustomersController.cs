using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmino.Service.Commands.CustomerCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Farmer has been created");
        }
    }
}
