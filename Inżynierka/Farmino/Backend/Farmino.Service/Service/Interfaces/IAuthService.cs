using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAuthService : IService
    {
        Task Login(string login, string password);
    }
}
