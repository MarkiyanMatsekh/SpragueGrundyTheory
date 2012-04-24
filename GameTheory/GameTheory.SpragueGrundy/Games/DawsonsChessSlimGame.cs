using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class DawsonsChessSlimGame : SpragueGrundyGameBase<uint>
    {
        protected override bool TryStopRecursion(uint key, out uint value)
        {
            if (key == 0)
            {
                value = 0;
                return true;
            }
            if (key == 1)
            {
                value = 1;
                return true;
            }
            value = 0;
            return false;
        }

        protected override HashSet<uint> GetSGValuesForTransitions(uint key)
        {
            var set = new HashSet<uint>();

            set.Add(SGValue(key - 2));
            for (uint i = 2; i <= key - 1; i++)
                set.Add(SGValue(i - 2) ^ SGValue(key - i - 1));

            return set;
        }
    }
}
