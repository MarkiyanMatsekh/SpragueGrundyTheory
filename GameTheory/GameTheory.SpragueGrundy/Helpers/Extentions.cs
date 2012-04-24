using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Helpers
{
    public static class Extentions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable )
        {
            return !enumerable.Any();
        }
    }
}
