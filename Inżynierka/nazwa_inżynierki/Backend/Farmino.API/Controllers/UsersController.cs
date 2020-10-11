using System.Threading.Tasks;
using Farmino.Service.Commands.User;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ICommandDispatcher _dispatcher;

        public UsersController(IUserService service, ICommandDispatcher dispatcher)
        {
            _service = service;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{login}")]
        public async Task<IActionResult> Get(string login)
        {
            var user = await _service.GetUserAsync(login);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
