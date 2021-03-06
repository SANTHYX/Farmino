using Farmino.Service.Commands.ObservedCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ObserveHandler
{
    public class ObserveOfferHandler : ICommandHandler<ObserveOffer>
    {
        private readonly IObservedService _observedService;

        public ObserveOfferHandler(IObservedService observedService)
        {
            _observedService = observedService;
        }

        public async Task HandleAsync(ObserveOffer command)
        {
            await _observedService.ObserveOfferAsync(command.UserName, command.OfferId);
        }
    }
}
