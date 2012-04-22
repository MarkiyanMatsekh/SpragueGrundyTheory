using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class LaskersNim : GrundyGameBase
    {
        protected override bool TryStop(uint n, out uint stop)
        {
            stop = 0;
            if (n ==0)
            {
                stop = 0;
                return true;
            }
            if (n == 1)
            {
                stop = 1;
                return true;
            }
            return false;
        }

        protected override HashSet<uint> GetGameTransitions(uint n)
        {
            var set = new HashSet<uint>();

            for (uint i = 0; i <= n - 1; i++)
                set.Add(Grundy(i));

            for (uint i = 1; i <= n - 1; i++)
                set.Add(Grundy(i) ^ Grundy(n - i));

            return set;
        }
    }

    public abstract class GrundyGameBase
    {
        private readonly Dictionary<uint, uint> _cache = new Dictionary<uint, uint>(); 

        protected uint Mex(HashSet<uint> set  )
        {
            //creepy implementation
            uint max = set.Max(), i = 0;
            for (; i <= max; i++)
            {
                if (!set.Contains(i))
                    break;
            }
            return i;
        }

        public uint Grundy(uint n)
        {
            uint grundyValue;
            if (TryStop(n, out grundyValue))
                return grundyValue;

            if (TryGetCachedValue(n, out grundyValue))
                return grundyValue;

            grundyValue = Mex(GetGameTransitions(n));

            CacheValue(n, grundyValue);

            return grundyValue;
        }

        private void CacheValue(uint u, uint grundyValue)
        {
            _cache[u] = grundyValue;
        }

        private bool TryGetCachedValue(uint n, out uint value)
        {
            return _cache.TryGetValue(n, out value);
        }

        protected abstract bool TryStop(uint n,out uint value);

        protected abstract HashSet<uint> GetGameTransitions(uint n);

    }
}
