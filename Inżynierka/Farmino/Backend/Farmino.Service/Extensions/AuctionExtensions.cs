using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class AuctionExtensions
    {
        public static async Task<Auction> GetIfExistAsync(this IAuctionRepository repository, Guid id)
        {
            var auction = await repository.GetAsync(id);

            if (auction == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AuctionDontExist,
                    $"Auction with Id {id} dont exist");
            }
            return auction;
        }
    }
}
