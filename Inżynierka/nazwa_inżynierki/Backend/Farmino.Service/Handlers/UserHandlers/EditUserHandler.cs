using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class EditUserHandler : ICommandHandler<EditUser>
    {
        private readonly IUserService _service;

        public EditUserHandler(IUserService service)
        {
            _service = service;
        }
        public async Task HandleAsync(EditUser command)
        {
            await _service.EditAsync(command.Login, command.NewLogin, command.NewPassword);
        }
    }
}
