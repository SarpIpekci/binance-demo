using System.Security.Cryptography;
using System.Text;

namespace BinanceReactDemo.Common.PasswordHashHelper
{
    public static class PasswordHash
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();

            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
