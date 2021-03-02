using Farmino.Data.Enums;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO.Offer;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Offer;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOfferService : IService
    {
        Task CreateOffer(string userName, string title,
            string description, WeightUnits minWeight, double minQuantity, Product product);
        Task MakeOrder(Guid offerId, string customerName, double orderQuantity,
            bool customAddress, OrderDetails orderDetails = null);
        Task RemoveOffer(Guid id);
        Task<OfferDTO> GetOfferAsync(Guid id);
        Task<DTO.PagedResponseDTO<OffersDTO>> BrowseAllAsync(PagedQuery paged,OfferQuery query);
        Task ObserveOfferAsync(string userName, Guid offerId);
    }
}
