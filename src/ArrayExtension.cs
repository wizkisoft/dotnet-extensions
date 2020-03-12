using System;
using System.Linq;

namespace Wizkisoft.DotNet.Extension
{
    public static class ArrayExtension
    {
        public static string JoinAll<T>(this T[] @this, string separator, Func<T, string> func) => string.Join(separator, @this.Select(func));
    }
}
