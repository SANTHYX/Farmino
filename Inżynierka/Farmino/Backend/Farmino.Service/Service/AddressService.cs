using Farmino.Data.Models.ValueObjects;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public AddressService(IUserRepository userRepository, 
            IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public async Task SetAddressAsync(string userName, string city, string street,
            string postalCode, int houseNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profil = await _profileRepository.GetIfExistAsync(user.Id);

            profil.SetAddress(Address.Create(city, street, postalCode, houseNumber));

            _profileRepository.EditProfile(profil);
            await _profileRepository.SaveChanges();
        }

        public async Task EditAddressAsync(string userName, string city, string street,
            string postalCode, int houseNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profil = await _profileRepository.GetIfExistAsync(user.Profile.Id);

            profil.Address.SetCity(city);
            profil.Address.SetStreet(street);
            profil.Address.SetPostalCode(postalCode);
            profil.Address.SetHouseNumber(houseNumber);

            _profileRepository.EditProfile(profil);
            await _profileRepository.SaveChanges();
        }
    }
}
