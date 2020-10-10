using Farmino.Service.DTO;
using Farmino.Service.Service.ServiceResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<ServiceResponse<UserDTO>> GetUserAsync();
        Task<ServiceResponse<IEnumerable<UserDTO>>> GetAllUsersAsync();
        Task <ServiceResponse<UserDTO>> RegisterUserAsync();
        Task <ServiceResponse<UserDTO>> EditUserAsync();
    }
}
