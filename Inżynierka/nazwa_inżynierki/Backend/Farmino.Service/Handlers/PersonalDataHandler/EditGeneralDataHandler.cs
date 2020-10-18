using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.PersonalDataHandler
{
    public class EditGeneralDataHandler : ICommandHandler<EditGeneralData>
    {
        private readonly IPersonalDataService _service;

        public EditGeneralDataHandler(IPersonalDataService service)
        {
            _service = service;
        }

        public async Task HandleAsync(EditGeneralData command)
        {
            await _service.EditGeneralDataAsync(command.Login, command.FirstName,
                command.LastName, command.PhoneNumber);
        }
    }
}
