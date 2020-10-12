using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.PersonalDataHandler
{
    public class EditPersonalDataHandler : ICommandHandler<EditPersonalData>
    {
        private readonly IPersonalDataService _service;

        public EditPersonalDataHandler(IPersonalDataService service)
        {
            _service = service;
        }

        public async Task HandleAsync(EditPersonalData command)
        {
            await _service.EditPersonalDataAsync(command.Login, command.FirstName,
                command.LastName, command.PhoneNumber);
        }
    }
}
