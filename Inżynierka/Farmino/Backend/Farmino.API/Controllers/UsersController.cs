using System.Collections.Generic;
using System.Threading.Tasks;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.DTO;
using Farmino.Service.Queries.UserQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        [Route("/users/single")]
        public async Task<IActionResult> Get([FromQuery] GetUser query)
            => Ok(await _queryDispatcher.HandleAsync<GetUser, UserDTO>(query));
        [Authorize]
        [HttpGet]
        [Route("/users/all")]
        public async Task<IActionResult> Get([FromQuery] BrowseUsers query)
          => Ok(await _queryDispatcher.HandleAsync<BrowseUsers, IEnumerable<UserDTO>>(query));

        [HttpGet]
        [Route("/users/isLoginAvaliable")]
        public async Task<IActionResult> Get([FromQuery] CheckIfLoginIsAvaliable query)
          => Ok(await _queryDispatcher.HandleAsync<CheckIfLoginIsAvaliable, LoginAvalibilityDTO>(query));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("User has been created completly");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("User has been updated completly");
        }
    }
}
