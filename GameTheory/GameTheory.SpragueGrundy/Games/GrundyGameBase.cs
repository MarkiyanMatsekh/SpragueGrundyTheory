using System;
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

    public class ChompGame : GrundyGameBase<Coordinate>
    {
        public uint N { get; private set; }
        public uint M { get; private set; }

        public ChompGame(uint n, uint m)
        {
            N = n;
            M = m;
        }

        protected override bool TryStopRecursion(Coordinate key, out uint value)
        {
            if (key.X <= 1 && key.Y <= 1)
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        protected override HashSet<uint> GetStateTransitions(Coordinate key)
        {
            var set = new HashSet<uint>();
            var map = new HashSet<Coordinate>();

            int y = key.Y;
            int x = key.X;

            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= M; j++)
                {
                    if ( i >= x && j >= y)
                        break;
                    map.Add(new Coordinate(i, j));
                    set.Add(SGValue(new Coordinate(i, j)));
                }

            throw new InvalidOperationException("This game has circular references in transitions, so no Sprague-Grundy solution is possible");
            return set;
        }
    }
}
