using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            => Ok(await _service.GetAllUsersAsync());


        [HttpGet("{login}")]
        public async Task<IActionResult> Get(string login)
            => Ok(await _service.GetUserAsync(login));


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {
            await _dispatcher.DispatchAsync(command);
            return Created("User has been created", await _service.GetUserAsync(command.Login));
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUser command)
        {
            await _dispatcher.DispatchAsync(command);
            return Created("User has been updated", await _service.GetUserAsync(command.NewLogin));
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
