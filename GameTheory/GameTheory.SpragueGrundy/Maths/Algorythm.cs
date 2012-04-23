using System.Collections.Generic;
using System.Linq;

namespace GameTheory.SpragueGrundy.Maths
{
    public static class Algorythm
    {
        public static uint Mex(HashSet<uint> set)
        {
            if (!set.Any())
                return 0;
            //creepy implementation
            uint max = set.Max(), i = 0;
            for (; i <= max; i++)
            {
                if (!set.Contains(i))
                    break;
            }
            return i;
        }
    }
}