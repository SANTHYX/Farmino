using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IFarmerService : IService
    {
        Task CreateFarmer(string login);
    }
}
