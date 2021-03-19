using Farmino.Data.Models.Entities;
using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class UpdateOfferHandler : ICommandHandler<UpdateOffer>
    {
        private readonly IOfferService _offerService;

        public UpdateOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(UpdateOffer command)
        {
            var product = Product.Create(command.Product.BasePrice, command.Product.BaseWeightUnit);
            await _offerService.UpdateOffer(command.Id, command.UserName, command.Title,
                command.Description, command.MinWeightUnit, command.MinQuantity, product);
        }
    }
}
