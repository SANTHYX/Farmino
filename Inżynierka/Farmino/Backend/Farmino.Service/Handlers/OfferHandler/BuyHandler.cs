using Farmino.Data.Models.ValueObjects;
using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class BuyHandler : ICommandHandler<Buy>
    {
        private readonly IOfferService _offerService;

        public BuyHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(Buy command)
        {
            if (command.CustomAddress)
            {
                var customAddress = Address.Create(command.Address.City,
                    command.Address.Street, command.Address.PostalCode, command.Address.HouseNumber);

                await _offerService.BuyAsync(command.CustomerName,
                    command.OfferId, command.BoughtQuantity, command.CustomAddress, customAddress);
            }
            else await _offerService.BuyAsync(command.CustomerName,
                    command.OfferId, command.BoughtQuantity, command.CustomAddress);
        }
    }
}
