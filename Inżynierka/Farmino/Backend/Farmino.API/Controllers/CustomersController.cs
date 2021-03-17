using System.Threading.Tasks;
using Farmino.Service.Commands.CustomerCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICustomerService _customerService; 

        public CustomersController(ICommandDispatcher commandDispatcher, 
            ICustomerService customerService)
        {
            _commandDispatcher = commandDispatcher;
            _customerService = customerService;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
            => Ok(await _customerService.GetAsync(userName));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Customer has been created");
        }
    }
}
