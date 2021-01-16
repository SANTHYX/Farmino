using Farmino.Data.Enums;
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
            string description, WeightUnits minWeight, double minQuantity, Product product);
        Task MakeOrder(Guid offerId, string customerName, double orderQuantity, WeightUnits orderUnit,
            bool customAddress, OrderDetails orderDetails = null);
        Task RemoveOffer(Guid id);
        Task<OfferDTO> GetOfferAsync(Guid id);
        Task<IEnumerable<OffersDTO>> BrowseAllAsync();
    }
}
