using Farmino.Data.Models.ValueObjects;
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

        public AddressService(IUserRepository userRepository, 
            IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public async Task SetAddressAsync(string userName, string city, string street,
            string postalCode, int houseNumber)
        {
            if (await _userRepository.IsUserExist(userName))
            {
                var user = await _userRepository.GetAsync(userName);
                var profil = await _profileRepository.GetAsync(user.Profile.Id);

                profil.SetAddress(Address.Create(city, street, postalCode, houseNumber));

                _profileRepository.EditProfile(profil);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Address on User that doesnt exist ");
        }

        public async Task EditAddressAsync(string userName, string city, string street,
            string postalCode, int houseNumber)
        {
            if (await _userRepository.IsUserExist(userName))
            {
                var user = await _userRepository.GetAsync(userName);
                var profil = await _profileRepository.GetAsync(user.Profile.Id);

                profil.Address.SetCity(city);
                profil.Address.SetStreet(street);
                profil.Address.SetPostalCode(postalCode);
                profil.Address.SetHouseNumber(houseNumber);

                _profileRepository.EditProfile(profil);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Address on User that doesnt exist ");
        }
    }
}
