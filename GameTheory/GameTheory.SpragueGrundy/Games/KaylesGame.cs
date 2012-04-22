using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class KaylesGame : GrundyGameBase
    {
        protected override bool TryStopRecursion(uint n, out uint value)
        {
            value = 0;
            if (n == 0)
            {
                value = 0;
                return true;
            }
            if (n == 1)
            {
                value = 1;
                return true;
            }
                
            return false;
        }

        protected override HashSet<uint> GetStateTransitions(uint n)
        {
            var set = new HashSet<uint>();

            for (uint i = 0; i <= n - 1; i++)
                set.Add(Grundy(i) ^ Grundy(n - 1 - i));

            for (uint i = 0; i <= n - 2; i++)
                set.Add(Grundy(i) ^ Grundy(n - 2 - i));

            return set;
        }
    }
}
