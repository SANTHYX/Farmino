using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Auction;
using Farmino.Service.DTO.Auction.NestedModels;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Queries.Auctions;
using Farmino.Service.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionerRepository _auctionerRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IParticipantAuctionRepository _participantAuctionRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public AuctionService(IAuctionRepository auctionRepository, IAuctionerRepository auctionerRepository,
            IMapper mapper, IParticipantAuctionRepository participantAuctionRepository ,
            IParticipantRepository participantRepository)
        {
            _auctionerRepository = auctionerRepository;
            _auctionRepository = auctionRepository;
            _participantAuctionRepository = participantAuctionRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task CreateAuction(string userName, string title, string description, 
            DateTime startDate, DateTime endDate, decimal startingPrice)
        {
            var auctioner = await _auctionerRepository.GetIfExistAsync(userName);

            await _auctionRepository.AddAsync(new Auction(title, description, startDate, endDate,
                startingPrice, auctioner));
            await _auctionRepository.SaveChangesAsync();
        }

        public async Task<AuctionDTO> GetAuction(Guid id)
        {
            var auction = await _auctionRepository.GetAsync(id);

            return _mapper.Map<Auction, AuctionDTO>(auction);
        }

        public async Task<IEnumerable<AuctionsDTO>> BrowseAuctions(AuctionsQuery query)
        {
            var auctions = _auctionRepository.GetAllAsync();

            if (query.Phrase != null)
            {
                auctions = auctions.Where(x => x.Title.ToLower().Contains(query.Phrase.ToLower()));
            }

            var result = await auctions.ToListAsync();

            return _mapper.Map<IEnumerable<AuctionsDTO>>(result);
        }

        public async Task ToAuction(string userName, Guid auctionId, decimal proposedPrice) 
        {
            var participant = await _participantRepository.GetIfExistAsync(userName);
            var auction = await _auctionRepository.GetIfExistAsync(auctionId);

            if (await _participantAuctionRepository.GetHighestPriceAsync(auctionId) > proposedPrice)
            {
                throw new ServiceExceptions(ServiceErrorCodes.YourPropositionIsToLow,
                    "Your proposed price is too low, you need to increase your budget");
            }

            await _participantAuctionRepository
                    .AddAsync(new ParticipantAuction(participant, auction, proposedPrice));
            await _participantAuctionRepository.SaveChangesAsync();
        }

        public async Task<ParticipantAuctionDTO> GetWinner(Guid auctionId)
        {
            var auction = await _auctionRepository.GetIfExistAsync(auctionId);

            if (auction.EndDate > DateTime.Now)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AuctionHasNotEndYet,
                    "Cannot get winner if auction is still active");
            }

            var winner = auction.Participants
                .OrderByDescending(x => x.ProposedPrice).FirstOrDefault();

            return _mapper.Map<ParticipantAuctionDTO>(winner);
        }
    }
}
