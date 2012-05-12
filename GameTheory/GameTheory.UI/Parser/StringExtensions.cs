namespace GameTheory.UI
{
    public static class StringExtensions
    {
        public static string SubstringAfter(this string str, char symbol)
        {
            return str.Substring(str.IndexOf(symbol) + 1);
        }
    }
}