using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAuctionerService : IService
    {
        Task CreateAuctioner(string userName);
    }
}
