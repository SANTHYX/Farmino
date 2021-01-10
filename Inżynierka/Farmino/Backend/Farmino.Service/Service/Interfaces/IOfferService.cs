using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO.Offer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOfferService : IService
    {
        Task CreateOffer(string userName, string title,
            string description, Product product);
        Task RemoveOffer(Guid id);
        Task<OfferDTO> GetOfferAsync(Guid id);
        Task<IEnumerable<OffersDTO>> BrowseAllAsync();
        Task BuyAsync(string customerName, Guid offerId,
                int boughtQuantity, bool customAddress, Address address = null);
    }
}
