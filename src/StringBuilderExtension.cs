using System.Text;
using Wizkisoft.DotNet.Format.Tab;

namespace Wizkisoft.DotNet.Extension
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendTab(this StringBuilder @this, int indent = 1) => @this.Append(Tab.Get(indent));

        public static StringBuilder AppendSpace(this StringBuilder @this) => @this.Append(" ");
    }
}
