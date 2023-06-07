using System;
using System.Text;

namespace MinhasFinancas.Api.Extensions
{
    public static class StringExtensions
    {
        public static string Decrypt(this string conectionString)
            => Encoding.UTF8.GetString(Convert.FromBase64String(conectionString));
    }
}
