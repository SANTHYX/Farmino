using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Geolocation.Interface;
using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Globalization;
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
            var geolocation = await _geolocation.GetNode(command.PostalCode, command.City,
                command.Street, command.HouseNumber);

            var node = Node.Create(Double.Parse(geolocation.lon, CultureInfo.InvariantCulture),
                Double.Parse(geolocation.lat, CultureInfo.InvariantCulture));

            await _service.EditAddressAsync(command.UserName, command.City, command.Street,
                command.PostalCode, command.HouseNumber, node);
        }
    }
}
