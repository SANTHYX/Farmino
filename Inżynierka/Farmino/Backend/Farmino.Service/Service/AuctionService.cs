using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Auction;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionerRepository _auctionerRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionService(IAuctionRepository auctionRepository, 
            IAuctionerRepository auctionerRepository, IMapper mapper)
        {
            _auctionerRepository = auctionerRepository;
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task CreateAuction(string userName, string title, string description, 
            DateTime startDate, DateTime endDate, decimal startingPrice)
        {
            var auctioner = await _auctionerRepository.GetIfExist(userName);
            await _auctionRepository.AddAsync(new Auction(title, description, startDate, endDate,
                startingPrice, auctioner));
            await _auctionRepository.SaveChangesAsync();
        }

        public async Task<AuctionDTO> GetAuction(Guid id)
        {
            var auction = await _auctionRepository.GetAsync(id);
            return _mapper.Map<Auction, AuctionDTO>(auction);
        }

        public async Task<IEnumerable<AuctionsDTO>> BrowseAuctions()
        {
            var auctions = await _auctionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Auction>, IEnumerable<AuctionsDTO>>(auctions);
        }
    }
}
