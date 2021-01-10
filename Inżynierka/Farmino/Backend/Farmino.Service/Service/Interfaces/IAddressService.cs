using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAddressService : IService
    {
        Task SetAddressAsync(string userName, string city, string street,
            string postalCode, string houseNumber);
        Task EditAddressAsync(string userName, string city, string street,
            string postalCode, string houseNumber);
    }
}
