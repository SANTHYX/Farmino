using Farmino.Service.DTO.User.NestedModels;

namespace Farmino.Service.DTO.User
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ProfileDTO Profile { get; set; }
    }
}
