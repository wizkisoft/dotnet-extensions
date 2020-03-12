namespace Wizkisoft.DotNet.Extension
{
    public static class StringExtension
    {
        public static string RemoveEverythingAfterTick(this string @this) => @this.IndexOf('`') < 0 ? @this : @this.Substring(0, @this.IndexOf('`'));
    }
}
