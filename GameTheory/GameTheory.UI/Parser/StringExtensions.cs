using System;

namespace GameTheory.UI.Parser
{
    public static class StringExtensions
    {
        public static string SubstringAfter(this string str, char symbol)
        {
            return str.Substring(str.IndexOf(symbol) + 1);
        }

        public static bool IsEmpty(this string str)
        {
            return str != null && str.Length == 0;
        }

        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}