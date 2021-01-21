using System.Threading.Tasks;

namespace Farmino.Infrastructure.Geolocation.Interface
{
    public interface IGeolocation
    {
        Task<GeolocationModel> GetNode(string postalCode, string city,
            string street, string houseNumber);
    }
}
