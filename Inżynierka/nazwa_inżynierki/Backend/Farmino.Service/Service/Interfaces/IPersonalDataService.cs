using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IPersonalDataService : IService
    {
        public Task SetPersonalDataAsync(string login, string firstName, 
            string lastName,string phoneNumber);
        public Task EditPersonalDataAsync(string login, string firstName,
            string lastName, string phoneNumber);
    }
}
