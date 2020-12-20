using Farmino.Service.DTO;

namespace Farmino.Service.Security.Interfaces
{
    public interface ITokenHandler
    {
        TokenDTO GenerateToken(UserDTO user);
        TokenDTO RefreshToken(TokenDTO token);
    }
}