using System.Reflection;
using System.Text.RegularExpressions;

namespace Wizkisoft.DotNet.Extension
{
    public static class MethodInfoExtension
    {
        public static bool IsConcreteInstance(this MethodInfo @this) => !@this.IsStatic && !@this.IsAbstract;

        public static bool IsProperty(this MethodInfo @this) => Regex.Match(@this.Name, "^(g|s)et_([A-Z]|[a-z])+").Length > 0;
    }
}
