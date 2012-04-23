using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Maths;

namespace GameTheory.SpragueGrundy.Games
{
    public abstract class GrundyGameBase<TKey>
    {
        private readonly Dictionary<TKey, uint> _cache = new Dictionary<TKey, uint>();

        public uint SGValue(TKey key)
        {
            uint grundyValue;

            if (TryStopRecursion(key, out grundyValue))
                return grundyValue;

            if (TryGetCachedValue(key, out grundyValue))
                return grundyValue;

            grundyValue = Algorythm.Mex(GetStateTransitions(key));

            CacheValue(key, grundyValue);

            return grundyValue;
        }

        protected abstract bool TryStopRecursion(TKey key, out uint value);

        protected abstract HashSet<uint> GetStateTransitions(TKey key);

        private void CacheValue(TKey key, uint grundyValue)
        {
            _cache[key] = grundyValue;
        }

        private bool TryGetCachedValue(TKey key, out uint value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }
}
