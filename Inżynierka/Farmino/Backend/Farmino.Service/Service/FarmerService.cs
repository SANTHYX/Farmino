using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class FarmerService : IFarmerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFarmerRepository _farmerRepository;

        public FarmerService(IUserRepository userRepository, 
            IFarmerRepository farmerRepository)
        {
            _userRepository = userRepository;
            _farmerRepository = farmerRepository;
        }

        public async Task CreateFarmer(string userName)
        {
            var user = await _userRepository.GetIfExistAsync(userName);

            if (!await _farmerRepository.IsFarmerExistAsync(userName))
            {
                await _farmerRepository.AddAsync(new Farmer(user));
                await _farmerRepository.SaveAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.FarmerAlreadyExist,
                "Farmer is already exist");
        }
    }
}
