using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
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
            CreateMap<RefreshToken, DTO.Token.TokenDTO>();
            CreateMap<Offer, DTO.Offer.OfferDTO>();
            CreateMap<Offer, DTO.Offer.OffersDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Product, DTO.Product.ProductDTO>();
            CreateMap<Weight, DTO.Product.NestedModels.WeightDTO>();
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
            CreateMap<LoginAvalibility, DTO.User.LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
