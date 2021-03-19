using System.Threading.Tasks;
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
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
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
          => Ok(await _userService.IsLoginAvaliableAsync(query.Login));
    }
}
