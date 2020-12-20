using Farmino.Service.Security.Interfaces;
using System;
using System.Security.Cryptography;

namespace Farmino.Service.Security
{
    public class Encryption : IEncryption
    {
        private static readonly int DeriveBytesIterationCount = 10000;
        private static readonly int SaltSize = 40;
        public string GenerateHash(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Cannot generate hash for empty password");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException("Cannot generate hash for empty salt");
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, GetBytes(salt), DeriveBytesIterationCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GenerateSalt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Cannot generate salt for empty string");
            }

            var bytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
