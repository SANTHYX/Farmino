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
            CreateMap<Profile, DTO.User.NestedModels.ProfileDTO>();
            CreateMap<Address, DTO.User.NestedModels.AddressDTO>();
            CreateMap<Address, DTO.Order.NestedModels.AddressDTO>();
            CreateMap<Node, DTO.User.NestedModels.NodeDTO>();
            CreateMap<Node, DTO.Order.NestedModels.NodeDTO>();
            CreateMap<RefreshToken, DTO.Token.TokenDTO>();
            CreateMap<Offer, DTO.Offer.OfferDTO>();
            CreateMap<Offer, DTO.Offer.OffersDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Product, DTO.Product.ProductDTO>();
            CreateMap<Farmer, DTO.Offer.NestedModels.FarmerDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Farmer, DTO.Farmer.FarmerDTO>();
            CreateMap<Auction, DTO.Auction.AuctionDTO>();
            CreateMap<Auction, DTO.Auction.AuctionsDTO>();
            CreateMap<Auctioner, DTO.Auction.NestedModels.AuctionerDTO>();
            CreateMap<Participant, DTO.Auction.NestedModels.ParticipantDTO>();
            CreateMap<ParticipantAuction, DTO.Auction.NestedModels.ParticipantAuctionDTO>();
            CreateMap<Customer, DTO.Customer.CustomerDTO>();
            CreateMap<Order, DTO.Order.OrderDTO>();
            CreateMap<Order, DTO.Order.OrdersDTO>();
            CreateMap<OrderDetails, DTO.Order.NestedModels.OrderDetailsDTO>();

            //Extensions
            CreateMap<LoginAvalibility, DTO.User.LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
