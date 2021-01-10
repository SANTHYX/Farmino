using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
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
            var weight = Weight.Create(command.Product.Weight.Unit, command.Product.Weight.Value);
            var product = Product.Create(command.Product.Price, command.Product.Quantity, weight);
            await _offerService.CreateOffer(command.UserName, command.Title,
                command.Description, product);
        }
    }
}
