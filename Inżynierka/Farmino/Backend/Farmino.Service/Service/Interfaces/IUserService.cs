using Farmino.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetUserAsync(string login);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task RegisterAsync(string login, string password, string email);
        Task EditAsync(string login, string newLogin, 
            string newPassword, string newEmail);
        Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string login);
    }
}
