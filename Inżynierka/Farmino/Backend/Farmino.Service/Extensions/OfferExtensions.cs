using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class OfferExtensions
    {
        public async static Task<bool> IsOfferExistAsync(this IOfferRepository repository, Guid id)
            => await repository.GetAsync(id) != null;

        public async static Task<Offer> GetIfExistAsync(this IOfferRepository repository, Guid id)
        {
            var offer = await repository.GetAsync(id);

            if(offer == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.OfferNotExist,
                    "Offer dont exist");
            }

            return offer;
        }
    }
}
