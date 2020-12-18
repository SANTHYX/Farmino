using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserService _service;

        public RegisterUserHandler(IUserService service, IProfileService dataService)
        {
            _service = service;
        }

        public async Task HandleAsync(RegisterUser command)
        {
            await _service.RegisterAsync(command.Login, command.Password, command.Email);
        }
    }
}
