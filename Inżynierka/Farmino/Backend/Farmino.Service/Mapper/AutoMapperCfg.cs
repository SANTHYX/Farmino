using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Offer;
using Farmino.Service.DTO.Offer.NestedModels;
using Farmino.Service.DTO.Token;
using Farmino.Service.DTO.User;
using Farmino.Service.DTO.User.NestedModels;
using Farmino.Service.Extensions.Models;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : AutoMapper.Profile
    {
        public AutoMapperCfg()
        {
            //Models
            CreateMap<User, DTO.User.UserDTO>();
            CreateMap<User, DTO.User.UsersDTO>();
            CreateMap<User, DTO.Offer.NestedModels.UserDTO>();
            CreateMap<User, DTO.Auction.NestedModels.UserDTO>();
            CreateMap<Data.Models.Entities.Profile, DTO.User.NestedModels.ProfileDTO>();
            CreateMap<Address, DTO.User.NestedModels.AddressDTO>();
            CreateMap<Address, DTO.Offer.NestedModels.FarmerDTO>();
            CreateMap<RefreshToken, TokenDTO>();
            CreateMap<Offer, OfferDTO>();
            CreateMap<Offer, OffersDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Weight, DTO.Offer.NestedModels.WeightDTO>();
            CreateMap<Farmer, DTO.Offer.NestedModels.FarmerDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Farmer, DTO.Farmer.FarmerDTO>();
            CreateMap<Auction, DTO.Auction.AuctionDTO>();
            CreateMap<Auction, DTO.Auction.AuctionsDTO>();
            CreateMap<Auctioner, DTO.Auction.NestedModels.AuctionerDTO>();
            CreateMap<Participant, DTO.Auction.NestedModels.ParticipantDTO>();
            CreateMap<ParticipantAuction, DTO.Auction.NestedModels.ParticipantAuctionDTO>();

            //Extensions
            CreateMap<LoginAvalibility, LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
