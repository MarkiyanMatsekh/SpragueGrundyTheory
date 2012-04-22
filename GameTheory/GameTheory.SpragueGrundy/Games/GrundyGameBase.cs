using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Maths;

namespace GameTheory.SpragueGrundy.Games
{
    public abstract class GrundyGameBase
    {
        private readonly Dictionary<uint, uint> _cache = new Dictionary<uint, uint>();

        public uint Grundy(uint n)
        {
            uint grundyValue;

            if (TryStopRecursion(n, out grundyValue))
                return grundyValue;

            if (TryGetCachedValue(n, out grundyValue))
                return grundyValue;

            grundyValue = Algorythm.Mex(GetStateTransitions(n));

            CacheValue(n, grundyValue);

            return grundyValue;
        }

        protected abstract bool TryStopRecursion(uint n, out uint value);

        protected abstract HashSet<uint> GetStateTransitions(uint n);

        private void CacheValue(uint u, uint grundyValue)
        {
            _cache[u] = grundyValue;
        }

        private bool TryGetCachedValue(uint n, out uint value)
        {
            return _cache.TryGetValue(n, out value);
        }
    }
}
