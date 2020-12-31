using Farmino.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetUserAsync(string userName);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task EditAsync(string userName, string newUserName, 
            string newPassword, string newEmail);
        Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string userName);
    }
}
