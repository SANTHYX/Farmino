using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO;
using Farmino.Service.Extensions.Models;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : AutoMapper.Profile
    {
        public AutoMapperCfg()
        {
            //Models
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Data.Models.Entities.Profile, ProfileDTO>().ReverseMap();
            CreateMap<Address,AddressDTO>().ReverseMap();
            CreateMap<RefreshToken, TokenDTO>().ReverseMap();
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Weight, WeightDTO>().ReverseMap();
            CreateMap<Farmer, FarmerDTO>().ReverseMap();

            //Extensions
            CreateMap<LoginAvalibility, LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
