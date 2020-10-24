using Farmino.Data.Models.Value_Objects;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IPersonalDataService : IService
    {
        public Task SetPersonalDataAsync(string login, string firstName, 
            string lastName,string phoneNumber, Address address);
        public Task EditGeneralDataAsync(string login, string firstName,
            string lastName, string phoneNumber);
        public Task EditPersonalAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber);
    }
}
