namespace Farmino.Service.Extensions.Models
{
    public class LoginAvalibility
    {
        public bool IsAvaliable { get; protected set; }

        public LoginAvalibility(bool value)
        {
            IsAvaliable = value;
        }

        public static LoginAvalibility Create(bool value)
            => new LoginAvalibility(value);
    }
}
