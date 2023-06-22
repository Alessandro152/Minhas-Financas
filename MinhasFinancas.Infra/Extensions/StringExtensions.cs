using System;
using System.Text;

namespace MinhasFinancas.Infra.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(this string value)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        public static string Decrypt(this string value)
            => Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
