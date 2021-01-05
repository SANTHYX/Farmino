using Farmino.Data.Models.Aggregations;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionerRepository _auctionerRepository;
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository, IAuctionerRepository auctionerRepository)
        {
            _auctionerRepository = auctionerRepository;
            _auctionRepository = auctionRepository;
        }

        public async Task CreateAuction(string userName, string title, string description, 
            DateTime startDate, DateTime endDate, decimal startingPrice)
        {
            var auctioner = await _auctionerRepository.GetIfExist(userName);
            await _auctionRepository.AddAsync(new Auction(title, description, startDate, endDate,
                startingPrice, auctioner));
            await _auctionRepository.SaveChangesAsync();
        }
    }
}
