using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IParticipantService : IService
    {
        Task CreateParticipant(string userName);
    }
}
