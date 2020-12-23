using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public async Task CreateProfileAsync(string login, string firstName,
            string lastName, string phoneNumber)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);
                var profile = new Profile(firstName, lastName, phoneNumber);

                profile.SetUser(user);

                await _profileRepository.CreateProfile(profile);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Profile on User that doesnt exist ");
        }

        public async Task EditProfileAsync(string login, string firstName,
            string lastName, string phoneNumber)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);
                var profil = await _profileRepository.GetAsync(user.Profile.Id);

                profil.SetFirstName(firstName);
                profil.SetLastName(lastName);
                profil.SetPhoneNumber(phoneNumber);

                _profileRepository.EditProfile(profil);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect Profile on User that doesnt exist ");
        }
    }
}
