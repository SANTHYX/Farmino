using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class RemoveOfferHandler : ICommandHandler<RemoveOffer>
    {
        private readonly IOfferService _offerService; 

        public RemoveOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(RemoveOffer command)
        {
            await _offerService.RemoveOffer(command.Id);
        }
    }
}
