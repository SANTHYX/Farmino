using Farmino.Data.Models.Entities;
using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class CreateOfferHandler : ICommandHandler<CreateOffer>
    {
        private readonly IOfferService _offerService;

        public CreateOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(CreateOffer command)
        {
            var product = Product.Create(command.Product.BasePrice, command.Product.BaseWeightUnit);
            await _offerService.CreateOffer(command.UserName, command.Title, command.Description, command.MinWeightUnit, command.MinQuantity, product);
        }
    }
}
