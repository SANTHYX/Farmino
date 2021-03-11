using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class DeactiveOfferHandler : ICommandHandler<DeactiveOffer>
    {
        private readonly IOfferService _offerService;

        public DeactiveOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(DeactiveOffer command)
        {
            await _offerService.DeactivateOffer(command.Id, command.UserName);
        }
    }
}
