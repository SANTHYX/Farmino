using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
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
            string postalCode, string houseNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profile = await _profileRepository.GetIfExistAsync(user.Id);

            if (profile.Address == null)
            {
                profile.SetAddress(Address.Create(city, street, postalCode, houseNumber));

                _profileRepository.EditProfile(profile);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.AddressAlreadyExist,
                "Address for that profile already exist");
        }

        public async Task EditAddressAsync(string userName, string city, string street,
            string postalCode, string houseNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profile = await _profileRepository.GetIfExistAsync(user.Id);

            if (profile.Address != null)
            {
                profile.Address.SetCity(city);
                profile.Address.SetStreet(street);
                profile.Address.SetPostalCode(postalCode);
                profile.Address.SetHouseNumber(houseNumber);

                _profileRepository.EditProfile(profile);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.AddressNotExist,
                "Address for that profile not exist");
        }
    }
}
