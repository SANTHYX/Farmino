using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IParticipantAuctionService
    {
        Task ToAuction(string userName, Guid auctionId, decimal proposedPrice);
    }
}
