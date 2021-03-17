using System.Threading.Tasks;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.DTO;
using Farmino.Service.DTO.User;
using Farmino.Service.Queries.UserQueries;
using Farmino.Service.Service.Interfaces;
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
        private readonly IUserService _userService;
        public UsersController(ICommandDispatcher commandDispatcher, IUserService userService,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
            => Ok(await _userService.GetUserAsync(userName));

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
          => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("/users/isLoginAvaliable")]
        public async Task<IActionResult> Get([FromQuery] CheckIfLoginIsAvaliable query)
          => Ok(await _queryDispatcher.HandleAsync<CheckIfLoginIsAvaliable, LoginAvalibilityDTO>(query));

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("User has been updated");
        }
    }
}
