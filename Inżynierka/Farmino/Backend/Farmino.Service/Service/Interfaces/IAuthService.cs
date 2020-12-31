using Farmino.Service.DTO;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAuthService : IService
    {
        Task RegisterAsync(string userName, string password, string email);
        Task<TokenDTO> Login(string userName, string password);
        Task<TokenDTO> RefreshToken(string token, string refresh);
        Task RevokeToken(string refresh);
    }
}
