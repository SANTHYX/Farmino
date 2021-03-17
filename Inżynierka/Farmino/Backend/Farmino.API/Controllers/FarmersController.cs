using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmino.Service.Commands.FarmerCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public FarmersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFarmer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Farmer has been created");
        }
    }
}
