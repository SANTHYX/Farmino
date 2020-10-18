using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IPersonalDataService : IService
    {
        public Task SetPersonalDataAsync(string login, string firstName, 
            string lastName,string phoneNumber, string city, string street, string postalCode, int houseNumber);
        public Task EditPersonalDataAsync(string login, string firstName,
            string lastName, string phoneNumber);
    }
}
