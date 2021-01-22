using Farmino.Data.Models.ValueObjects;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IAddressService : IService
    {
        Task SetAddressAsync(string userName, string city, string street,
            string postalCode, string houseNumber, Node node);
        Task EditAddressAsync(string userName, string city, string street,
            string postalCode, string houseNumber, Node node);
    }
}
