
using System.Collections.Generic;

namespace Wizkisoft.DotNet.Extension
{
    public static class IListExtension
    {
        public static IList<string> AddIf(this IList<string> @this, bool condition, string item)
        {
            if (condition)
                @this.Add(item);

            return @this;
        }
    }
}
