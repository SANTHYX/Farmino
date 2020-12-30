using Farmino.Service.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class OfferExtensions
    {
        public async static Task<bool> IsOfferExist(this IOfferRepository offerRepository, Guid id)
            => await offerRepository.GetAsync(id) != null;
    }
}
