using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ParticipantAuctionService : IParticipantAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IParticipantAuctionRepository _participantAuctionRepository;

        public ParticipantAuctionService(IAuctionRepository auctionRepository,
            IParticipantRepository participantRepository, IParticipantAuctionRepository participantAuctionRepository)
        {
            _auctionRepository = auctionRepository;
            _participantRepository = participantRepository;
            _participantAuctionRepository = participantAuctionRepository;
        }

        public async Task ToAuction(string userName, Guid auctionId, decimal proposedPrice)
        {
            var participant = await _participantRepository.GetIfExist(userName);
            var auction = await _auctionRepository.GetIfExistAsync(auctionId);

            if (await _participantAuctionRepository.GetHighestPriceAsync(auctionId) < proposedPrice)
            {
                await _participantAuctionRepository.AddAsync(new ParticipantAuction(participant,
                    auction, proposedPrice));
            }
            throw new ServiceExceptions(ServiceErrorCodes.YourPropositionIsToLow,
                "Your proposedPrice is to low comparing to other participants");
        }
    }
}
