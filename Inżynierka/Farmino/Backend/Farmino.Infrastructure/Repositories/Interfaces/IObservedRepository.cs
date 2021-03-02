using Farmino.Data.Models.Entities;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IObservedRepository : IRepository
    {
        Task Add(Observed observed);
        void Remove(Observed observed);
        Task SaveAsync();
    }
}
