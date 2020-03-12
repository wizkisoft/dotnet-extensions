using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wizkisoft.DotNet.Extension
{
    public static class TypeExtension
    {
        public static IEnumerable<MethodInfo> GetPublicConcreteMethods(this Type @this) =>
            @this.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.IsConcreteInstance() && !m.IsProperty());

        public static IEnumerable<PropertyInfo> GetPublicConcreteProperties(this Type @this) => @this.GetProperties().Where(p => p.GetAccessors().Where(m => m.IsConcreteInstance() && !m.IsConstructor).Count() > 0);

        public static string ToPrintable(this Type @this)
        {
            StringBuilder builder = new StringBuilder();

            if (@this.IsGenericType)
                return builder.Append(@this.Name.RemoveEverythingAfterTick())
                    .Append("<").Append(b => GetGenericTypeArguments(@this, b)).Append(">")
                    .ToString();

            return builder.Append(@this.Name).ToString();

            static StringBuilder GetGenericTypeArguments(Type @type, StringBuilder builder) => builder.Append(@type.GenericTypeArguments.JoinAll(", ", a => a.ToPrintable()));
        }
    }
}
