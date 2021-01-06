using Farmino.Service.DTO.Auction;
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
    }
}
