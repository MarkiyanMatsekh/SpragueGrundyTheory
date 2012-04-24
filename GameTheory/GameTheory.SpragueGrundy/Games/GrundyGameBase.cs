using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameTheory.SpragueGrundy.Maths;

namespace GameTheory.SpragueGrundy.Games
{
    public abstract class GrundyGameBase<TKey>
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
            grundyValue = Algorythm.Mex(GetStateTransitions(key));

            //Console.WriteLine(key.GetHashCode());
            //Thread.Sleep(100);

            CacheValue(key, grundyValue);

            return grundyValue;
        }

        protected abstract bool TryStopRecursion(TKey key, out uint value);

        protected abstract HashSet<uint> GetStateTransitions(TKey key);

        public virtual HashSet<TKey> GetStateTransitions2(TKey key)
        {
            //todo cleanup;
            return null;
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
