using System;
using System.Linq;

namespace Infra.ExtensionsMethods
{
    public static class StringExtensions
    {
        public static int ToInt(this string source)
        {
            return source.All(char.IsDigit) ? Convert.ToInt32(source) : 0;
        }
    }
}