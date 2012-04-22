using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class SticksGame : GrundyGameBase
    {
        private readonly uint _maxSticksToTake;

        public SticksGame(uint maxSticksToTake)
        {
            if (maxSticksToTake < 1)
                throw new ArgumentException("Max number of sticks to take at time must be positive");
            _maxSticksToTake = maxSticksToTake;
        }

        protected override bool TryStopRecursion(uint n, out uint value)
        {
            if (n <= _maxSticksToTake)
            {
                value = n; // or just 1 - doesn't really metter, but > 0
                return true;
            }

            value = 0;
            return false;
        }

        protected override HashSet<uint> GetStateTransitions(uint n)
        {
            var set = new HashSet<uint>();

            for (uint sticks = 1; sticks <= _maxSticksToTake; sticks++)
                set.Add(Grundy(n - sticks));

            return set;

        }
    }


}
