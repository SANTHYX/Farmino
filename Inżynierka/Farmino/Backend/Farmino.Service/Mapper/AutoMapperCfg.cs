using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.Value_Objects;
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
            //Extensions
            CreateMap<LoginAvalibility, LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
