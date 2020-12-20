namespace Farmino.Service.Security.Interfaces
{
    public interface IEncryption
    {
        string GenerateHash(string password, string salt);
        string GenerateSalt(string password);
    }
}
