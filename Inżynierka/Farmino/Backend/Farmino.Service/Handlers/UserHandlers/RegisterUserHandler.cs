using Farmino.Data.Models.Value_Objects;
using Farmino.Service.Commands.UserCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserService _service;
        private readonly IPersonalDataService _dataService;

        public RegisterUserHandler(IUserService service, IPersonalDataService dataService)
        {
            _service = service;
            _dataService = dataService;
        }

        public async Task HandleAsync(RegisterUser command)
        {
            await _service.RegisterAsync(command.Login, 
                command.Password, command.Email);

            var address = Address.Create(command.PersonalData.Address.City, command.PersonalData.Address.City,
                command.PersonalData.Address.PostalCode, command.PersonalData.Address.HouseNumber);

            await _dataService.SetPersonalDataAsync(command.Login, command.PersonalData.FirstName,
                command.PersonalData.LastName, command.PersonalData.PhoneNumber, address);

        }
    }
}
