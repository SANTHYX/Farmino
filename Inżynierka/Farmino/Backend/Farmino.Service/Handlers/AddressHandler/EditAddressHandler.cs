using Farmino.Infrastructure.Geolocation.Interface;
using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AddressHandler
{
    public class EditAddressHandler : ICommandHandler<EditAddress>
    {
        private readonly IAddressService _service;
        private readonly IGeolocation _geolocation;

        public EditAddressHandler(IAddressService service, IGeolocation geolocation)
        {
            _service = service;
            _geolocation = geolocation;
        }

        public async Task HandleAsync(EditAddress command)
        {
            await _service.EditAddressAsync(command.UserName, command.City, command.Street,
                command.PostalCode, command.HouseNumber);
        }
    }
}
