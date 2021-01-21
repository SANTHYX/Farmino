using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Geolocation.Interface;
using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class MakeOrderHandler : ICommandHandler<MakeOrder>
    {
        private readonly IOfferService _offerService;
        private readonly IGeolocation _geolocation;

        public MakeOrderHandler(IOfferService offerService, IGeolocation geolocation)
        {
            _offerService = offerService;
            _geolocation = geolocation;
        }

        public async Task HandleAsync(MakeOrder command)
        {
            if (command.CustomAddress)
            { 
                var address = Address.Create(command.OrderDetails.Address.City,
                    command.OrderDetails.Address.Street, command.OrderDetails.Address.PostalCode,
                    command.OrderDetails.Address.HouseNumber);

                var orderDetails = OrderDetails.Create(command.OrderDetails.FirstName,
                    command.OrderDetails.LastName, command.OrderDetails.PhoneNumber, address);

                await _offerService.MakeOrder(command.OfferId, command.CustomerName,
                    command.OrderQuantity, command.CustomAddress, orderDetails);
            }
            else await _offerService.MakeOrder(command.OfferId, command.CustomerName,
                command.OrderQuantity, command.CustomAddress);
        }
    }
}
