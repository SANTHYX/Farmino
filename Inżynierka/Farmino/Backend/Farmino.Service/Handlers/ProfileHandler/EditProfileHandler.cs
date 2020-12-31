using Farmino.Service.Commands.ProfileCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ProfileHandler
{
    public class EditProfileHandler : ICommandHandler<EditProfile>
    {
        private readonly IProfileService _service;

        public EditProfileHandler(IProfileService service)
        {
            _service = service;
        }
        public async Task HandleAsync(EditProfile command)
        {
            await _service.EditProfileAsync(command.UserName, command.FirstName,
                command.LastName, command.PhoneNumber);
        }
    }
}
