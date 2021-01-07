using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
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

        public async Task CreateProfileAsync(string userName, string firstName,
            string lastName, string phoneNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profile = new Profile(firstName, lastName, phoneNumber);

            if (!await _profileRepository.IsProfileExistAsync(user.Id))
            {
                profile.SetUser(user);

                await _profileRepository.CreateProfile(profile);
                await _profileRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.ProfileAlreadyExist,
                "Profil for this user already exist");
        }

        public async Task EditProfileAsync(string userName, string firstName,
            string lastName, string phoneNumber)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var profil = await _profileRepository.GetIfExistAsync(user.Id);

            profil.SetFirstName(firstName);
            profil.SetLastName(lastName);
            profil.SetPhoneNumber(phoneNumber);

            _profileRepository.EditProfile(profil);
            await _profileRepository.SaveChanges();
        }
    }
}
