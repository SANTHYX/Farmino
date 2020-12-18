using Farmino.Data.Models.Value_Objects;
using Farmino.Service.Exceptions;
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

        public AddressService()
        {

        }

        public async Task SetAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);
                var profil = await _profileRepository.GetAsync(user.Profile.Id);

                profil.SetAddress(new Address(city, street, postalCode, houseNumber));

                await _profileRepository.EditProfile(profil);
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Address on User that doesnt exist ");
        }

        public async Task EditAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);
                var profil = await _profileRepository.GetAsync(user.Profile.Id);

                profil.Address.SetCity(city);
                profil.Address.SetStreet(street);
                profil.Address.SetPostalCode(postalCode);
                profil.Address.SetHouseNumber(houseNumber);

                await _profileRepository.EditProfile(profil);
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Address on User that doesnt exist ");
        }
    }
}
