using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAddressService : IService
    {
        Task SetAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber);
        Task EditAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber);
    }
}
