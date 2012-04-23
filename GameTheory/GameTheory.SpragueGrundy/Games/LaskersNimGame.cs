using System.Collections.Generic;

namespace GameTheory.SpragueGrundy.Games
{
    public class LaskersNimGame : GrundyGameBase<uint>
    {
        protected override bool TryStopRecursion(uint n, out uint stop)
        {
            stop = 0;
            return n == 0;
        }

        protected override HashSet<uint> GetStateTransitions(uint n)
        {
            var set = new HashSet<uint>();

            for (uint i = 0; i <= n - 1; i++)
                set.Add(SGValue(i));

            for (uint i = 1; i <= n - 1; i++)
                set.Add(SGValue(i) ^ SGValue(n - i));

            return set;
        }
    }
}