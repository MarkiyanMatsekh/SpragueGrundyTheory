using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class SubstractionGame : GrundyGameBase
    {
        private readonly HashSet<uint> _substractionSet;

        public SubstractionGame(HashSet<uint> substractionSet)
        {
            if (!substractionSet.Any())
                throw new ArgumentException("substraction set cannot be empty");
            _substractionSet = substractionSet;
        }

        protected override bool TryStopRecursion(uint n, out uint value)
        {
            if (n  == 0)
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        protected override HashSet<uint> GetStateTransitions(uint n)
        {
            var set = new HashSet<uint>();

            foreach (var substraction in _substractionSet)
            {
                if (n < substraction)
                    continue;
                set.Add(Grundy(n - substraction));
            }

            return set;
        }
    }


}
