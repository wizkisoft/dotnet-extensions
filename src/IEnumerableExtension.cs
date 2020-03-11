using System;
using System.Collections.Generic;

namespace Wizkisoft.DotNet.Extension
{
    public static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
                action(item);
        }
    }
}
