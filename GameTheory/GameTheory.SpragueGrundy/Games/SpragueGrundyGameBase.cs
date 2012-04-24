using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GameTheory.SpragueGrundy.Maths;

namespace GameTheory.SpragueGrundy.Games
{
    public abstract class SpragueGrundyGameBase<TKey>
    {
        public int RecursionCount = 0;
        public int CachedRecCount = 0;

        public int CachedObjects { get { return _cache.Count; } }

        private readonly Dictionary<TKey, uint> _cache = new Dictionary<TKey, uint>();

        public uint SGValue(TKey key)
        {
            RecursionCount++;

            uint grundyValue;

            if (TryGetCachedValue(key, out grundyValue))
                return grundyValue;
            
            if (TryStopRecursion(key, out grundyValue))
                return grundyValue;

            CachedRecCount++;
            grundyValue = Algorythm.Mex(GetSGValuesForTransitions(key));

            CacheValue(key, grundyValue);

            return grundyValue;
        }

        protected abstract bool TryStopRecursion(TKey key, out uint value);

        protected abstract HashSet<uint> GetSGValuesForTransitions(TKey key);

        public virtual HashSet<TKey> GetStateTransitions(TKey key)
        {
            throw new IOException("The given game doesn't provide state transitions view, only sprague-grundy values");
        }
        
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
