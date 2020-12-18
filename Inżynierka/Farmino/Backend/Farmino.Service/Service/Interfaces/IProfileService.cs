using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IProfileService : IService
    {
        public Task SetProfileAsync(string login, string firstName, 
            string lastName,string phoneNumber);
        public Task EditProfileAsync(string login, string firstName,
            string lastName, string phoneNumber);
    }
}
