using Farmino.Service.DTO;
using Farmino.Service.Service.ServiceResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<ServiceResponse<UserDTO>> GetUserAsync(string login);
        Task<ServiceResponse<IEnumerable<UserDTO>>> GetAllUsersAsync();
        Task <ServiceResponse<UserDTO>> RegisterUserAsync(string firstName, string lastName,
            string login, string password, string email, int role);
        Task <ServiceResponse<UserDTO>> EditUserAsync();
    }
}
