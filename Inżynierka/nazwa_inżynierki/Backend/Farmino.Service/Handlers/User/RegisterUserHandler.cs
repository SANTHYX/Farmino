using Farmino.Service.Commands.User;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.User
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserService _service;

        public RegisterUserHandler(IUserService service)
        {
            _service = service;
        }
        public async Task HandleAsync(RegisterUser command)
        {
            await _service.RegisterUserAsync(command.FirstName, command.LastName,
                command.Login, command.Password, command.Email);
        }
    }
}
