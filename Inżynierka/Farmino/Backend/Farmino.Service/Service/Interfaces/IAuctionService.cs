using Farmino.Service.DTO.Auction;
using Farmino.Service.DTO.Auction.NestedModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAuctionService : IService
    {
        Task CreateAuction(string userName, string title, string description, DateTime startDate,
            DateTime endDate, decimal startingPrice);
        Task<AuctionDTO> GetAuction(Guid id);
        Task<IEnumerable<AuctionsDTO>> BrowseAuctions();
        Task ToAuction(string userName, Guid auctionId, decimal proposedPrice);
        Task<ParticipantAuctionDTO> GetWinner(Guid auctionId);
    }
}
