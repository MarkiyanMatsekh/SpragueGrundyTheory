using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class KaylesGame : GrundyGameBase<uint>
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

        protected override HashSet<uint> GetStateTransitions(uint key)
        {
            var set = new HashSet<uint>();

            for (uint i = 0; i <= key - 1; i++)
                set.Add(SGValue(i) ^ SGValue(key - 1 - i));

            for (uint i = 0; i <= key - 2; i++)
                set.Add(SGValue(i) ^ SGValue(key - 2 - i));

            return set;
        }
    }
}
