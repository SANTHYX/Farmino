using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuctionerService : IAuctionerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuctionerRepository _auctionerRepository;

        public AuctionerService(IUserRepository userRepository, 
            IAuctionerRepository auctionerRepository)
        {
            _userRepository = userRepository;
            _auctionerRepository = auctionerRepository;
        }

        public async Task CreateAuctioner(string userName)
        {
            var user = await _userRepository.GetIfExistAsync(userName);

            if (!await _auctionerRepository.IsAuctionerExist(userName))
            {
                await _auctionerRepository.AddAsync(new Auctioner(user));
                await _auctionerRepository.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.AuctionerAlreadyExist,
                "Auctioner with this userName already exist");
        }
    }
}
