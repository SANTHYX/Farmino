using Farmino.Service.DTO;
using Farmino.Service.DTO.Auction;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Auctions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAuctionService : IService
    {
        Task CreateAuction(string userName, string title, string description, DateTime startDate,
            DateTime endDate, string imageName, decimal startingPrice);
        Task<AuctionDTO> GetAuction(Guid id);
        Task<PagedResponseDTO<AuctionsDTO>> BrowseAuctions(PagedQuery paged, AuctionsQuery query);
        Task ToAuction(string userName, Guid auctionId, decimal proposedPrice);
        Task<PagedResponseDTO<ParticipantAuctionDTO>> AuctionOverviewAsync(PagedQuery paged, Guid auctionId);
        Task<ParticipantAuctionDTO> GetWinner(Guid auctionId);
    }
}
