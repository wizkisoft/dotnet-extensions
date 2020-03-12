using System;
using System.Text;

namespace Wizkisoft.DotNet.Extension
{
    public static class StringBuilderLambdaExtension
    {
        public static StringBuilder Append(this StringBuilder @this, Func<StringBuilder> func) => func();

        public static StringBuilder Append(this StringBuilder @this, Func<StringBuilder, StringBuilder> func) => func(@this);

        public static StringBuilder Append(this StringBuilder @this, Func<string> func) => @this.Append(func());
    }
}
