using Farmino.Service.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetUserAsync(string userName);
        Task<IEnumerable<UsersDTO>> GetAllUsersAsync();
        Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string userName);
    }
}
